using Microsoft.EntityFrameworkCore;
using Modular.Core.Models.Config;
using Modular.Core.Models.Entity;
using Modular.Core.Identity;
using Modular.Core.Models.Audit;
using Modular.Core.Models.Location;
using Modular.Core.Models.Misc;

namespace Modular.Core
{
    public class ModularDBContext : DbContext
    {

        #region "  Constructors  "

        public ModularDBContext(DbContextOptions<ModularDBContext> options) : base(options)
        {
        }

        #endregion

        #region "  DbSets  "
        
        public virtual DbSet<AuditLog> AuditLogs { get; set; }

        public virtual DbSet<Configuration> Configurations { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<Organisation> Organisations { get; set; }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public virtual DbSet<Continent> Continents { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Industry> Industries { get; set; }

        public virtual DbSet<Occupation> Occupations { get; set; }


        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigurationFactory.OnModelCreating(modelBuilder);
            ContactFactory.OnModelCreating(modelBuilder);
            OrganisationFactory.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ApplicationUser>()
                .ToTable("ApplicationUser")
                .HasKey(x => x.Id);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(x => x.Contact)
                .WithOne()
                .HasForeignKey<ApplicationUser>(x => x.ContactID);


            modelBuilder.Entity<ApplicationUser>()
                .Property(x => x.ContactID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ApplicationUser>()
                .HasIndex(e => e.ContactID)
                .IsUnique();
        }

    }
}
