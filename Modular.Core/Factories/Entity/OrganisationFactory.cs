using Microsoft.EntityFrameworkCore;
using Modular.Core.Helpers.Types;
using Modular.Core.Models.Entity;

namespace Modular.Core.Services.Factories.Entity
{
    public static class OrganisationFactory
    {

        public static Organisation Construct()
        {
            return new Organisation();
        }

        internal static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organisation>(entity =>
            {
                entity.ToTable("tblOrganisation");

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

                //  Name
                entity.Property(x => x.Name)
                      .HasColumnName("Name")
                      .HasColumnType("nvarchar(128)")
                      .IsRequired(true)
                      .HasDefaultValue(string.Empty)
                      .HasMaxLength(128);

                //  Description
                entity.Property(x => x.Description)
                      .HasColumnName("Description")
                      .HasColumnType("nvarchar(512)")
                      .IsRequired(false)
                      .HasDefaultValue(string.Empty)
                      .HasMaxLength(512);

                //  Registration Number
                entity.Property(x => x.RegistrationNumber)
                      .HasColumnName("RegistrationNumber")
                      .HasColumnType("nvarchar(64)")
                      .IsRequired(false)
                      .HasDefaultValue(string.Empty)
                      .HasMaxLength(64);

                //  Owner
                entity.Property(e => e.OwnerId)
                      .HasColumnName("OwnerID")
                      .HasColumnType("uniqueidentifier")
                      .HasDefaultValue(Guid.Empty)
                      .IsRequired(true);

                entity.HasOne(e => e.Owner)
                      .WithOne()
                      .HasForeignKey<Organisation>(e => e.OwnerId);

                entity.HasIndex(e => e.OwnerId)
                      .IsUnique(false);

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
                      .HasDefaultValue(Guid.Empty)
                      .IsRequired(false);

                entity.HasOne(e => e.AddressCountry)
                      .WithOne()
                      .HasForeignKey<Organisation>(e => e.AddressCountryId);

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

                //  Website Link
                entity.Property(e => e.Website)
                      .HasColumnName("Website")
                      .HasColumnType("nvarchar(2048)")
                      .IsRequired(false)
                      .HasDefaultValue(string.Empty)
                      .HasMaxLength(2048);

                //  Status
                entity.Property(e => e.Status)
                      .HasColumnName("Status")
                      .HasColumnType("int")
                      .HasDefaultValue(StatusType.Unknown)
                      .IsRequired(true);

            });

        }
    }
}
