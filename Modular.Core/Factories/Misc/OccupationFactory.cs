using Microsoft.EntityFrameworkCore;
using Modular.Core.Models.Misc;

namespace Modular.Core.Services.Factories.Misc
{
    public static class OccupationFactory
    {

        public static Occupation Construct()
        {
            return new Occupation();
        }


        internal static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Occupation>(entity =>
            {
                entity.ToTable("tblOccupation");

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
