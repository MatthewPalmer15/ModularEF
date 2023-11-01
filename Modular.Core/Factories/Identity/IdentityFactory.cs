using Microsoft.EntityFrameworkCore;
using Modular.Core.Identity;
using Modular.Core.Models.Entity;

namespace Modular.Core.Services.Factories.Identity
{
    public static class IdentityFactory
    {

        public static ApplicationUser Construct(Contact contact, string username, bool isStaff = false, bool isAdmin = false)
        {
            return new ApplicationUser()
            {
                CreatedDate = DateTime.Now,
                CreatedBy = Guid.Empty,
                ModifiedDate = DateTime.Now,
                ModifiedBy = Guid.Empty,
                ContactId = contact.Id,
                Contact = contact,
                UserName = username,
                Email = contact.Email,
                PhoneNumber = contact.Phone,
                IsStaff = isStaff,
                IsAdmin = isAdmin
            };
        }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("tblApplicationUser");

                //  ID
                entity.HasKey(e => e.ContactId)
                      .IsClustered(false);

                entity.HasIndex(e => e.ContactId)
                      .IsUnique(true);

                entity.Property(e => e.Id)
                      .HasColumnName("ID")
                      .HasColumnType("nvarchar(max)")
                      .ValueGeneratedOnAdd()
                      .IsRequired(true);

                //  Created Date
                entity.Property(e => e.CreatedDate)
                      .HasColumnName("CreatedDate")
                      .HasColumnType("datetime")
                      .HasDefaultValue(DateTime.MinValue)
                      .IsRequired(true);

                //  Created By
                entity.Property(e => e.CreatedBy)
                      .HasColumnName("CreatedBy")
                      .HasColumnType("uniqueidentifier")
                      .HasDefaultValue(Guid.Empty)
                      .IsRequired(true);

                //  Modified Date
                entity.Property(e => e.ModifiedDate)
                      .HasColumnName("ModifiedDate")
                      .HasColumnType("datetime")
                      .HasDefaultValue(DateTime.MinValue)
                      .IsRequired(true);

                //  Modified By
                entity.Property(e => e.ModifiedBy)
                      .HasColumnName("ModifiedBy")
                      .HasColumnType("uniqueidentifier")
                      .HasDefaultValue(Guid.Empty)
                      .IsRequired(true);

                //  Username
                entity.Property(e => e.UserName)
                      .HasColumnName("Username")
                      .HasColumnType("nvarchar(64)")
                      .IsRequired(true)
                      .HasDefaultValue(string.Empty)
                      .HasMaxLength(64);

                entity.Property(e => e.NormalizedUserName)
                      .HasColumnName("NormalizedUsername")
                      .HasColumnType("nvarchar(64)")
                      .IsRequired(false)
                      .HasDefaultValue(string.Empty)
                      .HasMaxLength(64);

                //  Email
                entity.Property(e => e.Email)
                      .HasColumnName("Email")
                      .HasColumnType("nvarchar(256)")
                      .IsRequired(true)
                      .HasDefaultValue(string.Empty)
                      .HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail)
                      .HasColumnName("NormalizedEmail")
                      .HasColumnType("nvarchar(256)")
                      .IsRequired(true)
                      .HasDefaultValue(string.Empty)
                      .HasMaxLength(256);

                //  Phone Number
                entity.Property(e => e.PhoneNumber)
                      .HasColumnName("Phone")
                      .HasColumnType("nvarchar(64)")
                      .IsRequired(false)
                      .HasDefaultValue(string.Empty)
                      .HasMaxLength(64);

                //  Password Hash
                entity.Property(e => e.PasswordHash)
                      .HasColumnName("PasswordHash")
                      .HasColumnType("nvarchar(max)")
                      .IsRequired(true);

                //  Email Confirmed
                entity.Property(e => e.EmailConfirmed)
                      .HasColumnName("EmailConfirmed")
                      .HasColumnType("bit")
                      .HasDefaultValue(false)
                      .IsRequired(true);

                //  Phone Number Confirmed
                entity.Property(e => e.PhoneNumberConfirmed)
                      .HasColumnName("PhoneNumberConfirmed")
                      .HasColumnType("bit")
                      .HasDefaultValue(false)
                      .IsRequired(true);

                //  Two Factor Enabled
                entity.Property(e => e.TwoFactorEnabled)
                      .HasColumnName("TwoFactorEnabled")
                      .HasColumnType("bit")
                      .HasDefaultValue(false)
                      .IsRequired(true);

                //  Lockout Enabled
                entity.Property(e => e.LockoutEnabled)
                      .HasColumnName("LockoutEnabled")
                      .HasColumnType("bit")
                      .HasDefaultValue(false)
                      .IsRequired(true);

                //  Lockout End
                entity.Property(e => e.LockoutEnd)
                      .HasColumnName("LockoutEnd")
                      .IsRequired(false);

                //  Access Failed Count
                entity.Property(e => e.AccessFailedCount)
                      .HasColumnName("AccessFailedCount")
                      .HasColumnType("int")
                      .HasDefaultValue(0)
                      .IsRequired(true);

                //  Security Stamp
                entity.Property(e => e.SecurityStamp)
                      .HasColumnName("SecurityStamp")
                      .HasColumnType("nvarchar(max)")
                      .IsRequired(false);

                //  Concurrency Stamp
                entity.Property(e => e.ConcurrencyStamp)
                      .HasColumnName("ConcurrencyStamp")
                      .HasColumnType("nvarchar(max)")
                      .IsRequired(false);

                //  Is Staff
                entity.Property(e => e.IsStaff)
                      .HasColumnName("IsStaff")
                      .HasColumnType("bit")
                      .HasDefaultValue(false)
                      .IsRequired(true);

                //  Is Admin
                entity.Property(e => e.IsAdmin)
                      .HasColumnName("IsAdmin")
                      .HasColumnType("bit")
                      .HasDefaultValue(false)
                      .IsRequired(true);

                //  Contact
                entity.Property(e => e.ContactId)
                      .HasColumnName("ContactID")
                      .HasColumnType("uniqueidentifier")
                      .HasDefaultValue(Guid.Empty)
                      .IsRequired(true);

                entity.HasOne(e => e.Contact)
                      .WithOne()
                      .HasForeignKey<ApplicationUser>(e => e.ContactId);

                entity.HasIndex(e => e.ContactId)
                      .IsUnique(true);

                entity.Navigation(e => e.Contact).AutoInclude();

            });

        }
    }
}
