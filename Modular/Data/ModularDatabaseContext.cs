using Microsoft.EntityFrameworkCore;
using Modular.Core.Models.Config;
using Modular.Core.Models.Entity;
using Modular.Core.Identity;

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
        
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Configuration> Configurations { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Organisation> Organisations { get; set; }



        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ContactFactory.OnModelCreating(modelBuilder);


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
