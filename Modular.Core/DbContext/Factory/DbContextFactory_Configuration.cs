using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DataEncryption;

namespace Modular.Core
{
    internal static partial class DbContextFactory
    {

        internal static class Configuration
        {

            internal static void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Entities.Concrete.Configuration>(entity =>
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
                          .HasColumnOrder(1)
                          .ValueGeneratedOnAdd()
                          .IsRequired(true);

                    //  Created
                    entity.Property(e => e.Created)
                          .HasColumnName("Created")
                          .HasColumnType("datetime")
                          .HasColumnOrder(2)
                          .HasDefaultValue(DateTime.Now)
                          .IsRequired(true);

                    //  Key
                    entity.Property(x => x.Key)
                          .HasColumnName("Key")
                          .HasColumnType("nvarchar(128)")
                          .HasColumnOrder(3)
                          .IsRequired(true)
                          .HasMaxLength(128);

                    entity.HasIndex(e => e.Key)
                          .IsUnique(true);

                    //  Value
                    entity.Property(x => x.Value)
                          .HasColumnName("Value")
                          .HasColumnType("nvarchar(max)")
                          .HasColumnOrder(4)
                          .IsRequired(true)
                          .IsEncrypted();

                    //  Status
                    entity.Property(e => e.Status)
                          .HasColumnName("Status")
                          .HasColumnType("int")
                          .HasColumnOrder(5)
                          .HasDefaultValue(StatusType.Active)
                          .IsRequired(true);

                });
            }

        }
    }
}
