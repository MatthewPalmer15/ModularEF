using Microsoft.EntityFrameworkCore;
using Modular.Core.Entities.Config;
using Modular.Core.Identity;

namespace Modular.Core
{
    public class ModularCoreDbContext : DbContext
    {

        #region "  Constructors  "

        public ModularCoreDbContext(DbContextOptions<ModularCoreDbContext> options) : base(options)
        {
        }

        #endregion

        #region "  DbSets  "

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Configuration> Configurations { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Contact>()
                .ToTable("Contact")
                .HasKey(x => x.ID);

            modelBuilder.Entity<Contact>()
                .Property(x => x.Forename)
                .IsRequired()
                .HasColumnName("Forename")
                .HasMaxLength(128);


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

        }

    }
}
