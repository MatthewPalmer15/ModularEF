using Microsoft.EntityFrameworkCore;
using Modular.Core.Models.Config;

namespace Modular.Core.Services.Factories.Config
{
    public static class ConfigurationFactory
    {

        public static Configuration Construct()
        {
            return new Configuration();
        }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.ToTable("tblConfiguration");

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
                      .IsRequired(true);

                //  Created By
                entity.Property(e => e.CreatedBy)
                      .HasColumnName("CreatedBy")
                      .HasColumnType("uniqueidentifier")
                      .IsRequired(true);

                //  Modified Date
                entity.Property(e => e.ModifiedDate)
                      .HasColumnName("ModifiedDate")
                      .HasColumnType("datetime")
                      .IsRequired(true);

                //  Modified By
                entity.Property(e => e.ModifiedBy)
                      .HasColumnName("ModifiedBy")
                      .HasColumnType("uniqueidentifier")
                      .IsRequired(true);

                //  Key
                entity.Property(x => x.Key)
                      .HasColumnName("Key")
                      .HasColumnType("nvarchar(128)")
                      .IsRequired(true)
                      .HasMaxLength(128);

                entity.HasIndex(e => e.Key)
                      .IsUnique(true);

                //  Value
                entity.Property(x => x.Value)
                      .HasColumnName("Value")
                      .HasColumnType("nvarchar(max)")
                      .IsRequired(true);

            });

        }
    }
}
