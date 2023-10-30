using Microsoft.EntityFrameworkCore;
using Modular.Core.Identity;
using Modular.Core.Models.Audit;

namespace Modular.Core.Services.Factories.Audit
{
    public static class AuditFactory
    {
        public static AuditLog Construct()
        {
            return new AuditLog();
        }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.ToTable("tblAuditLog");

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

                //  Message
                entity.Property(e => e.Message)
                      .HasColumnName("Message")
                      .HasColumnType("nvarchar(512)")
                      .HasMaxLength(512)
                      .IsRequired(true);

                //  Device Information
                entity.Property(e => e.DeviceInformation)
                      .HasColumnName("DeviceInformation")
                      .HasColumnType("nvarchar(256)")
                      .HasMaxLength(256)
                      .IsRequired(false);

            });
        }
    }
}
