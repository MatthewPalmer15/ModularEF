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

            modelBuilder.Entity<AuditTrail>(entity =>
            {
                entity.ToTable("tblAuditTrail");

                //  ID
                entity.HasKey(e => e.Id)
                      .IsClustered(false);


                entity.HasIndex(e => e.Id)
                      .IsUnique(true);


                entity.HasMany<AuditLog>(e => e.AuditLogs)
                      .WithOne(x => x.AuditTrail)
                      .HasForeignKey(x => x.AuditTrailId);

            });

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

                entity.HasOne<AuditTrail>(e => e.AuditTrail)
                      .WithMany(e => e.AuditLogs)
                      .HasForeignKey(e => e.AuditTrailId);

            });
        }
    }
}
