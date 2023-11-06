using Microsoft.EntityFrameworkCore;
using Modular.Core.Models.Entity;
using Modular.Core.Models.Location;

namespace Modular.Core.Services.Factories.Location
{
    public static class ContinentFactory
    {

        public static Continent Construct()
        {
            return new Continent();
        }


        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Continent>(entity =>
            {
                entity.ToTable("tblContinent");

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

            });
        }
    }
}
