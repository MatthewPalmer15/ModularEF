﻿using Microsoft.EntityFrameworkCore;
using Modular.Core.Models.Entity;

namespace Modular.Core.Services.Factories.Entity
{
    public static class ContactFactory
    {

        public static Contact Construct()
        {
            return new Contact();
        }

        public static Contact Construct(string Forename, string Surname, string Email)
        {
            return new Contact()
            {

                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                CreatedBy = Guid.Empty,
                ModifiedDate = DateTime.Now,
                ModifiedBy = Guid.Empty,
                Forename = Forename,
                Surname = Surname,
                Email = Email
            };
            
        }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
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

                //  Title
                entity.Property(e => e.Title)
                      .HasColumnName("Title")
                      .HasColumnType("int")
                      .HasDefaultValue(Contact.TitleType.Unknown)
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
                      .HasDefaultValue(Contact.GenderType.Unknown)
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
                //entity.Property(e => e.AddressCountryId)
                //      .HasColumnName("AddressCountryID")
                //      .HasColumnType("uniqueidentifier")
                //      .HasDefaultValue(Guid.Empty)
                //      .IsRequired(false);
                //
                //entity.HasOne(e => e.AddressCountry)
                //      .WithOne()
                //      .HasForeignKey<Contact>(e => e.AddressCountryId);

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
                
                //  Fax
                entity.Property(e => e.Fax)
                      .HasColumnName("Fax")
                      .HasColumnType("nvarchar(64)")
                      .IsRequired(false)
                      .HasDefaultValue(string.Empty)
                      .HasMaxLength(64);
                
                //  Facebook Link
                entity.Property(e => e.FacebookLink)
                      .HasColumnName("FacebookLink")
                      .HasColumnType("nvarchar(2048)")
                      .IsRequired(false)
                      .HasDefaultValue(string.Empty)
                      .HasMaxLength(2048);

                //  Instagram Link
                entity.Property(e => e.InstagramLink)
                      .HasColumnName("InstagramLink")
                      .HasColumnType("nvarchar(2048)")
                      .IsRequired(false)
                      .HasDefaultValue(string.Empty)
                      .HasMaxLength(2048);

                //  Twitter Link
                entity.Property(e => e.TwitterLink)
                      .HasColumnName("TwitterLink")
                      .HasColumnType("nvarchar(2048)")
                      .IsRequired(false)
                      .HasDefaultValue(string.Empty)
                      .HasMaxLength(2048);

                //  LinkedIn Link
                entity.Property(e => e.LinkedInLink)
                      .HasColumnName("LinkedInLink")
                      .HasColumnType("nvarchar(2048)")
                      .IsRequired(false)
                      .HasDefaultValue(string.Empty)
                      .HasMaxLength(2048);

                //  Website Link
                entity.Property(e => e.WebsiteLink)
                      .HasColumnName("WebsiteLink")
                      .HasColumnType("nvarchar(2048)")
                      .IsRequired(false)
                      .HasDefaultValue(string.Empty)
                      .HasMaxLength(2048);

                //  Occupation
                //entity.Property(e => e.OccupationId)
                //      .HasColumnName("OccupationID")
                //      .HasColumnType("uniqueidentifier")
                //      .HasDefaultValue(Guid.Empty)
                //      .IsRequired(false);
                //
                //entity.HasOne(e => e.Occupation)
                //      .WithOne()
                //      .HasForeignKey<Contact>(e => e.OccupationId);

                //  Department
                //entity.Property(e => e.DepartmentId)
                //      .HasColumnName("DepartmentID")
                //      .HasColumnType("uniqueidentifier")
                //      .HasDefaultValue(Guid.Empty)
                //      .IsRequired(false);
                //
                //entity.HasOne(e => e.Department)
                //      .WithOne()
                //      .HasForeignKey<Contact>(e => e.DepartmentId);

                //  Organisation
                //entity.Property(e => e.OrganisationId)
                //      .HasColumnName("OrganisationID")
                //      .HasColumnType("uniqueidentifier")
                //      .HasDefaultValue(Guid.Empty)
                //      .IsRequired(false);
                //
                //entity.HasOne(e => e.Organisation)
                //      .WithOne()
                //     .HasForeignKey<Contact>(e => e.OrganisationId);

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
