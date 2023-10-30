using Microsoft.EntityFrameworkCore;
using Modular.Core.Identity;

namespace Modular.Core.Services.Factories.Identity
{
    public static class IdentityFactory
    {

        public static ApplicationUser Construct()
        {
            return new ApplicationUser();
        }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("tblApplicationUser");

                entity.HasKey(e => e.Id)
                      .IsClustered(false);


                entity.Property(e => e.Id)
                      .HasColumnName("ID")
                      .ValueGeneratedNever()
                      .IsRequired();


                entity.Property(x => x.UserName)
                      .HasColumnName("Username")
                      .IsRequired()
                      .HasMaxLength(64);

                entity.Property(x => x.NormalizedUserName)
                      .HasColumnName("NormalizedUsername")
                      .HasMaxLength(64);

                entity.Property(x => x.Email)
                      .HasColumnName("Email")
                      .IsRequired()
                      .HasMaxLength(256);

                entity.Property(x => x.NormalizedEmail)
                      .HasColumnName("NormalizedEmail")
                      .HasMaxLength(256);

                entity.Property(x => x.PhoneNumber)
                      .HasColumnName("PhoneNumber")
                      .HasMaxLength(32);

                entity.Property(x => x.PasswordHash)
                      .HasColumnName("PasswordHash")
                      .IsRequired();

                entity.Property(x => x.EmailConfirmed)
                      .HasColumnName("EmailConfirmed");

                entity.Property(x => x.PhoneNumberConfirmed)
                      .HasColumnName("PhoneNumberConfirmed");

                entity.Property(x => x.TwoFactorEnabled)
                      .HasColumnName("TwoFactorEnabled");

                entity.Property(x => x.LockoutEnabled)
                      .HasColumnName("LockoutEnabled");

                entity.Property(x => x.LockoutEnd)
                      .HasColumnName("LockoutEnd");

                entity.Property(x => x.AccessFailedCount)
                      .HasColumnName("AccessFailedCount");

                entity.Property(x => x.SecurityStamp)
                      .HasColumnName("SecurityStamp");

                entity.Property(x => x.ConcurrencyStamp)
                      .HasColumnName("ConcurrencyStamp");

                entity.Property(x => x.IsStaff)
                      .HasColumnName("IsStaff");

                entity.Property(x => x.IsAdmin)
                      .HasColumnName("IsAdmin");

                entity.Property(x => x.ContactID)
                    .HasColumnName("ContactID")
                    .ValueGeneratedOnAdd();
                
                entity.HasOne(x => x.Contact)
                      .WithOne()
                      .HasForeignKey<ApplicationUser>(x => x.ContactID);
                
                entity.HasIndex(e => e.ContactID)
                      .IsUnique();
                
                entity.Property(x => x.IsStaff)
                      .HasColumnName("IsStaff");
                
                entity.Property(x => x.IsAdmin)
                      .HasColumnName("IsAdmin");


            });

        }
    }
}
