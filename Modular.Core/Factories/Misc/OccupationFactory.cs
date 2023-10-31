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


        public static void OnModelCreating(ModelBuilder modelBuilder)
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
