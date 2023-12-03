using Microsoft.EntityFrameworkCore;

namespace Modular.Core
{
    internal static partial class DbContextFactory
    {

        internal static class Contact
        {

            internal static void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Models.Entity.Contact>(entity =>
                {
                    entity.ToTable("tblContact");

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

                    //  Title
                    entity.Property(e => e.Title)
                          .HasColumnName("Title")
                          .HasColumnType("int")
                          .HasDefaultValue(Models.Entity.Contact.TitleType.Unknown)
                          .IsRequired(false);

                    //  Forename
                    entity.Property(e => e.Forename)
                          .HasColumnName("Forename")
                          .HasColumnType("nvarchar(128)")
                          .IsRequired(true)
                          .HasDefaultValue(string.Empty)
                          .HasMaxLength(128);

                    //  Surname
                    entity.Property(e => e.Surname)
                          .HasColumnName("Surname")
                          .HasColumnType("nvarchar(128)")
                          .IsRequired(true)
                          .HasDefaultValue(string.Empty)
                          .HasMaxLength(128);

                    // Date Of Birth
                    entity.Property(e => e.DateOfBirth)
                          .HasColumnName("DateOfBirth")
                          .HasColumnType("date")
                          .IsRequired(true)
                          .HasDefaultValue(DateTime.MinValue);

                    //  Gender
                    entity.Property(e => e.Gender)
                          .HasColumnName("Gender")
                          .HasColumnType("int")
                          .HasDefaultValue(Models.Entity.Contact.GenderType.Unknown)
                          .IsRequired(false);

                    //  Address Line 1
                    entity.Property(e => e.AddressLine1)
                          .HasColumnName("AddressLine1")
                          .HasColumnType("nvarchar(128)")
                          .IsRequired(false)
                          .HasDefaultValue(string.Empty)
                          .HasMaxLength(128);

                    //  Address Line 2
                    entity.Property(e => e.AddressLine2)
                          .HasColumnName("AddressLine2")
                          .HasColumnType("nvarchar(128)")
                          .IsRequired(false)
                          .HasDefaultValue(string.Empty)
                          .HasMaxLength(128);

                    //  Address Line 3
                    entity.Property(e => e.AddressLine3)
                          .HasColumnName("AddressLine3")
                          .HasColumnType("nvarchar(128)")
                          .IsRequired(false)
                          .HasDefaultValue(string.Empty)
                          .HasMaxLength(128);

                    //  Address City
                    entity.Property(e => e.AddressCity)
                          .HasColumnName("AddressCity")
                          .HasColumnType("nvarchar(128)")
                          .IsRequired(false)
                          .HasDefaultValue(string.Empty)
                          .HasMaxLength(128);

                    //  Address County
                    entity.Property(e => e.AddressCounty)
                          .HasColumnName("AddressCounty")
                          .HasColumnType("nvarchar(128)")
                          .IsRequired(false)
                          .HasDefaultValue(string.Empty)
                          .HasMaxLength(128);

                    //  Address Country
                    entity.Property(e => e.AddressCountryId)
                          .HasColumnName("AddressCountryID")
                          .HasColumnType("uniqueidentifier")
                          .HasDefaultValue(null)
                          .IsRequired(false);

                    entity.HasOne(e => e.AddressCountry)
                          .WithOne()
                          .HasForeignKey<Models.Entity.Contact>(e => e.AddressCountryId);

                    //  Address Postcode
                    entity.Property(e => e.AddressPostcode)
                          .HasColumnName("AddressPostcode")
                          .HasColumnType("nvarchar(128)")
                          .IsRequired(false)
                          .HasDefaultValue(string.Empty)
                          .HasMaxLength(128);

                    //  Email
                    entity.Property(e => e.Email)
                          .HasColumnName("Email")
                          .HasColumnType("nvarchar(256)")
                          .IsRequired(true)
                          .HasDefaultValue(string.Empty)
                          .HasMaxLength(256);

                    //  Phone
                    entity.Property(e => e.Phone)
                          .HasColumnName("Phone")
                          .HasColumnType("nvarchar(64)")
                          .IsRequired(false)
                          .HasDefaultValue(string.Empty)
                          .HasMaxLength(64);

                    //  Mobile
                    entity.Property(e => e.Mobile)
                          .HasColumnName("Mobile")
                          .HasColumnType("nvarchar(64)")
                          .IsRequired(false)
                          .HasDefaultValue(string.Empty)
                          .HasMaxLength(64);

                    //  Organisation
                    entity.Property(e => e.OrganisationId)
                          .HasColumnName("OrganisationID")
                          .HasColumnType("uniqueidentifier")
                          .HasDefaultValue(null)
                          .IsRequired(false);

                    entity.HasOne(e => e.Organisation)
                          .WithOne()
                         .HasForeignKey<Models.Entity.Contact>(e => e.OrganisationId);

                    //  Is Verified
                    entity.Property(e => e.IsVerified)
                          .HasColumnName("IsVerified")
                          .HasColumnType("bit")
                          .HasDefaultValue(false)
                          .IsRequired(true);

                    //  Is Banned
                    entity.Property(e => e.IsBanned)
                          .HasColumnName("IsBanned")
                          .HasColumnType("bit")
                          .HasDefaultValue(false)
                          .IsRequired(true);

                });

            }

        }
    }
}
