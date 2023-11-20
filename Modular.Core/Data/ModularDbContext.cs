﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.DataEncryption.Providers;
using Modular.Core.Interfaces;
using Modular.Core.Models.Audit;
using Modular.Core.Models.Config;
using Modular.Core.Models.Entity;
using Modular.Core.Models.Location;
using Modular.Core.Models.Misc;
using Modular.Core.Services.Factories.Config;
using Modular.Core.Services.Factories.Entity;
using Modular.Core.Services.Factories.Location;
using Modular.Core.Services.Factories.Misc;
using Newtonsoft.Json;

namespace Modular.Core
{
    public class ModularDbContext : DbContext
    {

        #region "  Constructors  "

        public ModularDbContext()
        {
            _encryptionProvider = new AesProvider(EncryptionKey, EncryptionIV);
        }

        public ModularDbContext(DbContextOptions<ModularDbContext> options) : base(options)
        {
            _encryptionProvider = new AesProvider(EncryptionKey, EncryptionIV);
        }

        #endregion

        #region "  Constants  "

        internal static readonly byte[] EncryptionKey = new byte[32] { 218, 67, 67, 63, 204, 244, 241, 114, 106, 200, 253, 68, 254, 170, 233, 174, 241, 127, 130, 233, 16, 17, 217, 204, 18, 174, 7, 247, 196, 98, 133, 163 };

        internal static readonly byte[] EncryptionIV = new byte[16] { 58, 191, 153, 193, 2, 157, 167, 89, 225, 55, 84, 168, 83, 75, 77, 242 };

        private readonly IEncryptionProvider _encryptionProvider;

        #endregion

        #region "  DbSets  "

        public virtual DbSet<AuditEntry> AuditEntries { get; set; }

        public virtual DbSet<AuditLog> AuditRequestLogs { get; set; }

        public virtual DbSet<Configuration> Configurations { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<Organisation> Organisations { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Occupation> Occupations { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");
            modelBuilder.HasDefaultSchema("dbo");

            //  Config
            ConfigurationFactory.OnModelCreating(modelBuilder);

            //  Entity
            ContactFactory.OnModelCreating(modelBuilder);
            OrganisationFactory.OnModelCreating(modelBuilder);
            
            //  Location
            CountryFactory.OnModelCreating(modelBuilder);

            //  Misc
            DepartmentFactory.OnModelCreating(modelBuilder);
            OccupationFactory.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuditEntry>(entity =>
            {
                entity.ToTable("tblAuditEntry");

                entity.Property(e => e.EntityObject).HasConversion(
                    value => JsonConvert.SerializeObject(value),
                    serializedValue => JsonConvert.DeserializeObject<Dictionary<string, object>>(serializedValue) ?? new Dictionary<string, object>()
                );
            });

            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.ToTable("tblAuditLog");
            });

            modelBuilder.UseEncryption(_encryptionProvider);
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
