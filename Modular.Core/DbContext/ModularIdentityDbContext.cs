using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Modular.Core.Entities.Abstract;
using Modular.Core.Entities.Concrete;
using Modular.Core.Identity;
using Modular.Core.Interfaces;
using System.Security.Claims;

namespace Modular.Core
{

    /// <summary>
    /// Modular DB Context with ASP.NET Identity
    /// </summary>
    public class ModularIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IDbContext
    {

        private readonly IEncryptionProvider _encryptionProvider;

        private readonly IHttpContextAccessor _httpContextAccessor;

        #region "  Constructors  "

        /// <summary>
        /// Creates DbContext with new instances.
        /// </summary>
        public ModularIdentityDbContext()
        {
            _encryptionProvider = SystemUtils.GetEncryptionProvider();
            _httpContextAccessor = new HttpContextAccessor();
        }

        /// <summary>
        /// Creates DBContext with dependency injection.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="httpContextAccessor"></param>
        public ModularIdentityDbContext(DbContextOptions<ModularIdentityDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
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

        public Guid CurrentUserId
        {
            get
            {
                string? userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return !string.IsNullOrWhiteSpace(userId) ? new Guid(userId) : Guid.Empty;
            }
        }

        #region "  Overriden Methods  "

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");
            builder.HasDefaultSchema("dbo");

            //  Audit
            DbContextFactory.Audit.OnModelCreating(builder);

            //  Config
            DbContextFactory.Configuration.OnModelCreating(builder);

            //  Entity
            DbContextFactory.Contact.OnModelCreating(builder);
            DbContextFactory.Company.OnModelCreating(builder);

            //  Identity
            DbContextFactory.Identity.OnModelCreating(builder);

            //  Invoicing
            DbContextFactory.Invoicing.OnModelCreating(builder);

            //  Location
            DbContextFactory.Country.OnModelCreating(builder);

            builder.UseEncryption(_encryptionProvider);
        }

        #endregion

        #region "  Save Methods  "

        private List<AuditEntry> BeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            List<AuditEntry> auditEntries = [];

            foreach (EntityEntry entry in ChangeTracker.Entries())
            {
                IAuditEntry.ActionType actionType = DbContextUtils.ConvertToActionType(entry.State);

                if (actionType != IAuditEntry.ActionType.Unknown && entry.Entity is IAuditable)
                {
                    auditEntries.Add(DbContextUtils.CreateAuditEntry(entry, actionType, CurrentUserId));
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
            AuditEntries.AddRange(auditEntries);
            return SaveChangesAsync();
        }

        #endregion

    }
}
