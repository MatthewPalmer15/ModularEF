using Microsoft.EntityFrameworkCore;
using Modular.Core.Identity;
using Modular.Core.Models.Entity;

namespace Modular.Core.Services.Factories.Entity
{
    public static class OrganisationFactory
    {

        public static Organisation Construct()
        {
            return new Organisation();
        }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organisation>(entity =>
            {
                entity.ToTable("tblOrganisation");

                entity.HasKey(e => e.Id)
                      .IsClustered(false);

                entity.Property(e => e.Id)
                      .HasColumnName("ID")
                      .ValueGeneratedNever()
                      .IsRequired();


                entity.Property(x => x.CreatedDate)
                      .HasColumnName("CreatedDate")
                      //.ValueGeneratedOnAdd()
                      .IsRequired();

                entity.Property(x => x.CreatedBy)
                      .HasColumnName("CreatedBy")
                      //.ValueGeneratedOnAdd()
                      .IsRequired();

                entity.Property(x => x.ModifiedDate)
                      .HasColumnName("ModifiedDate")
                      //.ValueGeneratedOnUpdate()
                      .IsRequired();

                entity.Property(x => x.ModifiedBy)
                      .HasColumnName("ModifiedBy")
                      //.ValueGeneratedOnUpdate()
                      .IsRequired();

                entity.Property(x => x.Name)
                      .HasColumnName("Name")
                      .IsRequired()
                      .HasMaxLength(128);

                entity.Property(x => x.Description)
                      .HasColumnName("Description")
                      .HasMaxLength(256);

                entity.Property(x => x.RegistrationNumber)
                      .HasColumnName("RegistrationNumber")
                      .HasMaxLength(128);

                entity.Property(x => x.ContactId)
                      .HasColumnName("OwnerID")
                      .IsRequired();

                entity.HasOne(x => x.Contact)
                      .WithOne()
                      .HasForeignKey<Organisation>(x => x.ContactId);

                entity.HasIndex(e => e.ContactId)
                      .IsUnique();

                entity.Property(x => x.AddressLine1)
                      .HasColumnName("AddressLine1")
                      .HasMaxLength(128);

                entity.Property(x => x.AddressLine2)
                      .HasColumnName("AddressLine2")
                      .HasMaxLength(128);

                entity.Property(x => x.AddressLine3)
                      .HasColumnName("AddressLine3")
                      .HasMaxLength(128);

                entity.Property(x => x.AddressCity)
                      .HasColumnName("AddressCity")
                      .HasMaxLength(128);

                entity.Property(x => x.AddressCounty)
                      .HasColumnName("AddressCounty")
                      .HasMaxLength(128);

                entity.Property(x => x.AddressCountryID)
                      .HasColumnName("AddressCountryID");

                entity.HasOne(x => x.AddressCountry)
                      .WithOne()
                      .HasForeignKey<Organisation>(x => x.AddressCountryID);

                entity.HasIndex(e => e.AddressCountryID)
                      .IsUnique();

                entity.Property(x => x.AddressPostcode)
                      .HasColumnName("AddressPostcode")
                      .HasMaxLength(128);

                entity.Property(x => x.Email)
                      .HasColumnName("Email")
                      .HasMaxLength(128);

                entity.Property(x => x.Telephone)
                      .HasColumnName("Telephone")
                      .HasMaxLength(128);

                entity.Property(x => x.Website)
                      .HasColumnName("Website")
                      .HasMaxLength(128);

                entity.Property(x => x.Status)
                      .HasColumnName("Status")
                      .HasColumnType("int")
                      .IsRequired();

            });

        }
    }
}
