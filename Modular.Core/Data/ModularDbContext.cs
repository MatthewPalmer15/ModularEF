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

namespace Modular.Core
{
    public class ModularDbContext : IdentityDbContext<ApplicationUser>
    {

        #region "  Constructors  "

        public ModularDbContext()
        {
        }

        public ModularDbContext(DbContextOptions<ModularDbContext> options) : base(options)
        {
        }

        #endregion

        #region "  DbSets  "

        public virtual DbSet<AuditLog> AuditLogs { get; set; }

        public virtual DbSet<Configuration> Configurations { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<Organisation> Organisations { get; set; }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }

        public virtual DbSet<Continent> Continents { get; set; }

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
            //ContinentFactory.OnModelCreating(modelBuilder);
            //CountryFactory.OnModelCreating(modelBuilder);

            //  Misc
            //DepartmentFactory.OnModelCreating(modelBuilder);
            //OccupationFactory.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });

            modelBuilder.Ignore<Continent>();
            modelBuilder.Ignore<Country>();
            modelBuilder.Ignore<Department>();
            modelBuilder.Ignore<Occupation>();

        }

    }
}
