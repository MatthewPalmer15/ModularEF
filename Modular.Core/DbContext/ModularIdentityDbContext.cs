﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Modular.Core.Identity;
using Modular.Core.Interfaces;
using Modular.Core.Models.Audit;
using Modular.Core.Models.Config;
using Modular.Core.Models.Entity;
using Modular.Core.Models.Location;
using Modular.Core.Services.Factories.Config;
using Modular.Core.Services.Factories.Entity;
using Modular.Core.Services.Factories.Identity;
using Modular.Core.Services.Factories.Location;
using Newtonsoft.Json;

namespace Modular.Core
{

    /// <summary>
    /// Modular DB Context with ASP.NET Identity
    /// </summary>
    public class ModularIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {

        #region "  Constructors  "

        public ModularIdentityDbContext()
        {
            _encryptionProvider = SystemUtils.GetEncryptionProvider();
        }

        public ModularIdentityDbContext(DbContextOptions<ModularIdentityDbContext> options) : base(options)
        {
            _encryptionProvider = SystemUtils.GetEncryptionProvider();
        }

        #endregion

        #region "  Constants  "


        private readonly IEncryptionProvider _encryptionProvider;

        #endregion

        #region "  DbSets  "

        public virtual DbSet<AuditEntry> AuditEntries { get; set; }

        public virtual DbSet<AuditLog> AuditLogs { get; set; }

        public virtual DbSet<Configuration> Configurations { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<Organisation> Organisations { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }

        public virtual DbSet<ApplicationUserProfile> ApplicationUserProfiles { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");
            builder.HasDefaultSchema("dbo");

            //  Config
            ConfigurationFactory.OnModelCreating(builder);

            //  Entity
            ContactFactory.OnModelCreating(builder);
            OrganisationFactory.OnModelCreating(builder);

            //  Identity
            IdentityFactory.OnModelCreating(builder);

            //  Location
            CountryFactory.OnModelCreating(builder);

            builder.Entity<AuditEntry>(entity =>
            {
                entity.ToTable("tblAuditEntry");

                entity.Property(e => e.EntityObject).HasConversion(
                    value => JsonConvert.SerializeObject(value),
                    serializedValue => JsonConvert.DeserializeObject<Dictionary<string, object>>(serializedValue) ?? new Dictionary<string, object>()
                );
            });

            builder.Entity<AuditLog>(entity =>
            {
                entity.ToTable("tblAuditLog");
            });

            builder.UseEncryption(_encryptionProvider);
        }

        private List<AuditEntry> BeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            List<AuditEntry> auditEntries = new List<AuditEntry>();

            foreach (EntityEntry entry in ChangeTracker.Entries())
            {

                AuditEntry.ActionType actionType;
                switch (entry.State)
                {
                    case EntityState.Added:
                        actionType = AuditEntry.ActionType.Create;
                        break;

                    case EntityState.Modified:
                        actionType = AuditEntry.ActionType.Update;
                        break;

                    case EntityState.Deleted:
                        actionType = AuditEntry.ActionType.Delete;
                        break;

                    default:
                        actionType = AuditEntry.ActionType.Unknown;
                        break;

                }

                if (actionType != AuditEntry.ActionType.Unknown && entry.Entity is IAuditable)
                {
                    AuditEntry auditEntry = new AuditEntry()
                    {
                        Id = Guid.NewGuid(),
                        Timestamp = DateTime.UtcNow,
                        Action = actionType,
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

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            List<AuditEntry> auditEntries = BeforeSaveChanges();

            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

            await AfterSaveChangesAsync(auditEntries);
            return result;

        }

        public Task AfterSaveChangesAsync(List<AuditEntry> auditEntries)
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
    }
}