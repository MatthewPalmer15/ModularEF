﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Modular.Core.Entities.Abstract;
using Modular.Core.Entities.Concrete;
using Modular.Core.Interfaces;
using System.Security.Claims;

namespace Modular.Core
{

    /// <summary>
    /// Modular DB Context without ASP.NET Identity
    /// </summary>
    public class ModularDbContext : DbContext, IDbContext
    {

        private readonly IEncryptionProvider _encryptionProvider;

        private readonly IHttpContextAccessor _httpContextAccessor;

        #region "  Constructors  "

        public ModularDbContext()
        {
            _encryptionProvider = SystemUtils.GetEncryptionProvider();
            _httpContextAccessor = new HttpContextAccessor();
        }

        public ModularDbContext(DbContextOptions<ModularDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _encryptionProvider = SystemUtils.GetEncryptionProvider();
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region "  DbSets  "

        public virtual DbSet<AuditEntry> AuditEntries { get; set; }

        public virtual DbSet<AuditLog> AuditLogs { get; set; }

        public virtual DbSet<Configuration> Configurations { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<Company> Companies { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");
            modelBuilder.HasDefaultSchema("dbo");

            //  Audit
            DbContextFactory.Audit.OnModelCreating(modelBuilder);

            //  Config
            DbContextFactory.Configuration.OnModelCreating(modelBuilder);

            //  Entity
            DbContextFactory.Contact.OnModelCreating(modelBuilder);
            DbContextFactory.Company.OnModelCreating(modelBuilder);

            //  Invoicing
            DbContextFactory.Invoicing.OnModelCreating(modelBuilder);

            //  Location
            DbContextFactory.Country.OnModelCreating(modelBuilder);

            modelBuilder.UseEncryption(_encryptionProvider);
        }

        #region "  Save Methods  "

        private List<AuditEntry> BeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            List<AuditEntry> auditEntries = new List<AuditEntry>();

            foreach (EntityEntry entry in ChangeTracker.Entries())
            {

                IAuditEntry.ActionType actionType;
                switch (entry.State)
                {
                    case EntityState.Added:
                        actionType = IAuditEntry.ActionType.Create;
                        break;

                    case EntityState.Modified:
                        actionType = IAuditEntry.ActionType.Update;
                        break;

                    case EntityState.Deleted:
                        actionType = IAuditEntry.ActionType.Delete;
                        break;

                    default:
                        actionType = IAuditEntry.ActionType.Unknown;
                        break;

                }

                if (actionType != IAuditEntry.ActionType.Unknown && entry.Entity is IAuditable)
                {
                    var currentUserID = new Guid(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? Guid.Empty.ToString());

                    AuditEntry auditEntry = new AuditEntry()
                    {
                        Id = Guid.NewGuid(),
                        Timestamp = DateTime.UtcNow,
                        Action = actionType,
                        ApplicationUserId = currentUserID,
                        EntityId = entry.Properties.Single(p => p.Metadata.IsPrimaryKey()).CurrentValue?.ToString() ?? "",
                        EntityName = entry.Metadata.ClrType.Name,
                        EntityObject = entry.Properties.Select(p => new { p.Metadata.Name, p.CurrentValue }).ToDictionary(i => i.Name, i => i.CurrentValue),

                        // TempProperties are properties that are only generated on save, e.g. ID's
                        // These properties will be set correctly after the audited entity has been saved
                        TempProperties = entry.Properties.Where(p => p.IsTemporary).ToList(),
                    };

                    auditEntries.Add(auditEntry);
                }
            }
            return auditEntries;
        }

        public override int SaveChanges() => SaveChanges(acceptAllChangesOnSuccess: true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            List<AuditEntry> auditEntries = BeforeSaveChanges();
            var result = base.SaveChanges(acceptAllChangesOnSuccess);
            AfterSaveChangesAsync(auditEntries);
            return result;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            await SaveChangesAsync(true, cancellationToken);

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            List<AuditEntry> auditEntries = BeforeSaveChanges();

            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

            await AfterSaveChangesAsync(auditEntries);
            return result;

        }

        private Task AfterSaveChangesAsync(List<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count == 0)
            {
                return Task.CompletedTask;
            }
            else
            {
                // For each temporary property in each audit entry - update the value in the audit entry to the actual (generated) value
                foreach (var entry in auditEntries)
                {
                    foreach (var prop in entry.TempProperties)
                    {
                        if (prop.Metadata.IsPrimaryKey())
                        {
                            entry.EntityId = prop.CurrentValue?.ToString() ?? "";
                            entry.EntityObject[prop.Metadata.Name] = prop.CurrentValue;
                        }
                        else
                        {
                            entry.EntityObject[prop.Metadata.Name] = prop.CurrentValue;
                        }
                    }
                }
            }

            AuditEntries.AddRange(auditEntries);
            return SaveChangesAsync();
        }

        #endregion
    }
}
