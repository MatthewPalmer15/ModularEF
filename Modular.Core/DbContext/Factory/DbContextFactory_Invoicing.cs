using Microsoft.EntityFrameworkCore;
using Modular.Core.Entities.Concrete;

namespace Modular.Core
{
    internal static partial class DbContextFactory
    {

        internal static class Invoicing
        {

            internal static void OnModelCreating(ModelBuilder modelBuilder)
            {

                modelBuilder.Ignore<Invoice>();
                modelBuilder.Ignore<InvoiceItem>();
                modelBuilder.Ignore<InvoicePayment>();

                // modelBuilder.Entity<Invoice>(entity =>
                // {
                //     entity.ToTable("tblInvoice");
                // 
                //     //  ID
                //     entity.HasKey(e => e.Id)
                //           .IsClustered(false);
                // 
                //     entity.HasIndex(e => e.Id)
                //           .IsUnique(true);
                // 
                //     entity.Property(e => e.Id)
                //           .HasColumnName("ID")
                //           .HasColumnType("uniqueidentifier")
                //           .ValueGeneratedOnAdd()
                //           .IsRequired(true);
                // 
                //     //  Created
                //     entity.Property(e => e.Created)
                //           .HasColumnName("Created")
                //           .HasColumnType("datetime")
                //           .HasDefaultValue(DateTime.Now)
                //           .IsRequired(true);
                // 
                //     entity.Property(e => e.InvoiceNumber)
                //           .HasColumnType("int")
                //           .IsRequired(true);
                // 
                //     entity.HasMany(e => e.Items)
                //           .WithOne()
                //           .HasForeignKey(e => e.InvoiceId);
                // 
                //     entity.HasMany(e => e.Payments)
                //           .WithOne()
                //           .HasForeignKey(e => e.InvoiceId);
                // 
                //     entity.Property(e => e.InvoiceDate)
                //           .HasColumnType("date")
                //           .HasDefaultValue(DateOnly.MinValue)
                //           .IsRequired(true);
                // 
                //     entity.Property(e => e.DueDate)
                //           .HasColumnType("date")
                //           .HasDefaultValue(DateOnly.MinValue)
                //           .IsRequired(true);
                // 
                // });
                // 
                // 
                // modelBuilder.Entity<InvoiceItem>(entity =>
                // {
                //     entity.ToTable("tblInvoiceItem");
                // 
                //     //  ID
                //     entity.HasKey(e => e.Id)
                //           .IsClustered(false);
                // 
                //     entity.HasIndex(e => e.Id)
                //           .IsUnique(true);
                // 
                //     entity.Property(e => e.Id)
                //           .HasColumnName("ID")
                //           .HasColumnType("uniqueidentifier")
                //           .ValueGeneratedOnAdd()
                //           .IsRequired(true);
                // 
                //     //  Created
                //     entity.Property(e => e.Created)
                //           .HasColumnName("Created")
                //           .HasColumnType("datetime")
                //           .HasDefaultValue(DateTime.Now)
                //           .IsRequired(true);
                // 
                //     entity.Property(e => e.Name)
                //           .HasColumnType("nvarchar(128)")
                //           .HasDefaultValue(0)
                //           .IsRequired(true);
                // 
                //     entity.Property(e => e.Description)
                //           .HasColumnType("nvarchar(256)")
                //           .HasDefaultValue(0)
                //           .IsRequired(true);
                // 
                //     entity.Property(e => e.Net)
                //           .HasColumnType("decimal(18,6)")
                //           .HasDefaultValue(0)
                //           .IsRequired(true);
                // 
                //     entity.Property(e => e.VAT)
                //           .HasColumnType("decimal(18,6)")
                //           .HasDefaultValue(0)
                //           .IsRequired(true);
                // 
                //     entity.Property(e => e.Discount)
                //           .HasColumnType("decimal(18,6)")
                //           .HasDefaultValue(0)
                //           .IsRequired(true);
                // 
                //     entity.Property(e => e.Quantity)
                //           .HasColumnType("int")
                //           .HasDefaultValue(0)
                //           .IsRequired(true);
                // 
                // });

            }
        }
    }
}
