using Microsoft.EntityFrameworkCore;
using Modular.Core.Identity;
using Modular.Core.Services.Factories.Audit;
using Modular.Core.Services.Factories.Config;
using Modular.Core.Services.Factories.Entity;
using Modular.Core.Services.Factories.Identity;
using Modular.Core.Services.Factories.Location;
using Modular.Core.Services.Factories.Misc;
using Modular.Core.Models.Audit;
using Modular.Core.Models.Config;
using Modular.Core.Models.Entity;
using Modular.Core.Models.Location;
using Modular.Core.Models.Misc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.DataEncryption.Providers;
using System.Text;

namespace Modular.Core
{
    public class ModularDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {

        #region "  Constructors  "

        public ModularDbContext()
        {
        }

        public ModularDbContext(DbContextOptions<ModularDbContext> options) : base(options)
        {
            _encryptionProvider = new AesProvider(EncryptionKey, EncryptionIV);
        }

        #endregion

        #region "  Constants  "

        internal static readonly byte[] EncryptionKey = new byte[32]{ 218, 67, 67, 63, 204, 244, 241, 114, 106, 200, 253, 68, 254, 170, 233, 174, 241, 127, 130, 233, 16, 17, 217, 204, 18, 174, 7, 247, 196, 98, 133, 163 };

        internal static readonly byte[] EncryptionIV = new byte[16]{ 58, 191, 153, 193, 2, 157, 167, 89, 225, 55, 84, 168, 83, 75, 77, 242 };

        private readonly IEncryptionProvider _encryptionProvider;

        #endregion

        #region "  DbSets  "

        public virtual DbSet<AuditLog> AuditLogs { get; set; }

        public virtual DbSet<Configuration> Configurations { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<Organisation> Organisations { get; set; }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Occupation> Occupations { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");
            //base.OnModelCreating(modelBuilder);

            //  Audit
            AuditFactory.OnModelCreating(modelBuilder);

            //  Config
            ConfigurationFactory.OnModelCreating(modelBuilder);

            //  Entity
            ContactFactory.OnModelCreating(modelBuilder);
            OrganisationFactory.OnModelCreating(modelBuilder);

            //  Identity
            IdentityFactory.OnModelCreating(modelBuilder);

            //  Location
            CountryFactory.OnModelCreating(modelBuilder);

            //  Misc
            DepartmentFactory.OnModelCreating(modelBuilder);
            OccupationFactory.OnModelCreating(modelBuilder);

            modelBuilder.UseEncryption(_encryptionProvider);

        }

    }
}
