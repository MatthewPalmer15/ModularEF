using Microsoft.EntityFrameworkCore;

namespace Modular.Core
{
    internal static partial class DbContextFactory
    {

        internal static class Country
        {

            internal static void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Entities.Country>(entity =>
                {
                    entity.ToTable("tblCountry");

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

                    //  Code
                    entity.Property(x => x.Code)
                          .HasColumnName("Code")
                          .HasColumnType("nvarchar(16)")
                          .IsRequired(false)
                          .HasDefaultValue(string.Empty)
                          .HasMaxLength(16);

                });

            }

        }

    }
}
