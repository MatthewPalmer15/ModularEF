using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modular.Core.Identity;

namespace Modular.Core
{
    internal static partial class DbContextFactory
    {

        internal static class Identity
        {

            internal static void OnModelCreating(ModelBuilder modelBuilder)
            {

                modelBuilder.Entity<ApplicationUser>(entity =>
                {
                    entity.ToTable("tblApplicationUser");

                    //  ID
                    entity.HasKey(e => e.Id)
                          .IsClustered(false);

                    entity.HasIndex(e => e.Id)
                          .IsUnique(true);

                    entity.Property(e => e.Id)
                          .HasColumnName("ID")
                          .HasColumnType("uniqueidentifier")
                          .ValueGeneratedOnAdd()
                          .IsRequired(true);

                    ////  Created Date
                    //entity.Property(e => e.CreatedDate)
                    //      .HasColumnName("CreatedDate")
                    //      .HasColumnType("datetime")
                    //      .HasDefaultValue(DateTime.MinValue)
                    //      .IsRequired(true);
                    //
                    ////  Created By
                    //entity.Property(e => e.CreatedBy)
                    //      .HasColumnName("CreatedBy")
                    //      .HasColumnType("uniqueidentifier")
                    //      .HasDefaultValue(Guid.Empty)
                    //      .IsRequired(true);
                    //
                    ////  Modified Date
                    //entity.Property(e => e.ModifiedDate)
                    //      .HasColumnName("ModifiedDate")
                    //      .HasColumnType("datetime")
                    //      .HasDefaultValue(DateTime.MinValue)
                    //      .IsRequired(true);
                    //
                    ////  Modified By
                    //entity.Property(e => e.ModifiedBy)
                    //      .HasColumnName("ModifiedBy")
                    //      .HasColumnType("uniqueidentifier")
                    //      .HasDefaultValue(Guid.Empty)
                    //      .IsRequired(true);

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

                    //  Contact
                    entity.Property(e => e.ContactId)
                          .HasColumnName("ContactID")
                          .HasColumnType("uniqueidentifier")
                          .HasDefaultValue(Guid.Empty)
                          .IsRequired(true);

                    entity.HasOne(e => e.Contact)
                          .WithOne()
                          .HasForeignKey<ApplicationUser>(e => e.ContactId)
                          .OnDelete(DeleteBehavior.Cascade);

                    entity.HasIndex(e => e.ContactId)
                          .IsUnique(true);

                    entity.Navigation(e => e.Contact).AutoInclude();
                });

                // modelBuilder.Entity<ApplicationUserProfile>(entity =>
                // {
                //     entity.ToTable("tblApplicationUserProfile");
                // 
                //     //  Facebook Link
                //     entity.Property(e => e.FacebookLink)
                //           .HasColumnName("FacebookLink")
                //           .HasColumnType("nvarchar(2048)")
                //           .IsRequired(false)
                //           .HasDefaultValue(string.Empty)
                //           .HasMaxLength(2048);
                // 
                //     //  Instagram Link
                //     entity.Property(e => e.InstagramLink)
                //           .HasColumnName("InstagramLink")
                //           .HasColumnType("nvarchar(2048)")
                //           .IsRequired(false)
                //           .HasDefaultValue(string.Empty)
                //           .HasMaxLength(2048);
                // 
                //     //  Twitter Link
                //     entity.Property(e => e.TwitterLink)
                //           .HasColumnName("TwitterLink")
                //           .HasColumnType("nvarchar(2048)")
                //           .IsRequired(false)
                //           .HasDefaultValue(string.Empty)
                //           .HasMaxLength(2048);
                // 
                //     //  LinkedIn Link
                //     entity.Property(e => e.LinkedInLink)
                //           .HasColumnName("LinkedInLink")
                //           .HasColumnType("nvarchar(2048)")
                //           .IsRequired(false)
                //           .HasDefaultValue(string.Empty)
                //           .HasMaxLength(2048);
                // 
                //     //  Website Link
                //     entity.Property(e => e.WebsiteLink)
                //           .HasColumnName("WebsiteLink")
                //           .HasColumnType("nvarchar(2048)")
                //           .IsRequired(false)
                //           .HasDefaultValue(string.Empty)
                //           .HasMaxLength(2048);
                // });

                modelBuilder.Entity<ApplicationRole>(entity =>
                {
                    entity.ToTable("tblApplicationRole");
                });

                modelBuilder.Entity<IdentityRoleClaim<Guid>>(entity =>
                {
                    entity.ToTable("tblApplicationRoleClaim");
                });

                modelBuilder.Entity<IdentityUserLogin<Guid>>(entity =>
                {
                    entity.ToTable("tblApplicationUserLogin");
                    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
                });

                modelBuilder.Entity<IdentityUserRole<Guid>>(entity =>
                {
                    entity.ToTable("tblApplicationUserRole");
                    entity.HasKey(e => new { e.UserId, e.RoleId });
                });

                modelBuilder.Entity<IdentityUserToken<Guid>>(entity =>
                {
                    entity.ToTable("tblApplicationUserToken");
                    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
                });

                modelBuilder.Entity<IdentityUserClaim<Guid>>(entity =>
                {
                    entity.ToTable("tblApplicationUserClaim");
                    entity.HasKey(e => new { e.UserId, e.Id });
                });
            }

        }
    }
}
