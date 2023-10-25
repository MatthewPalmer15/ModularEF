using Microsoft.EntityFrameworkCore;
using Modular.Core.Config;
using Modular.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Models.Config
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
                entity.HasKey(e => e.ID)
                      .IsClustered(false);

                entity.Property(e => e.ID)
                      .HasColumnName("ID")
                      .HasColumnType("uniqueidentifier")
                      .ValueGeneratedNever()
                      .IsRequired();

                entity.HasIndex(e => e.ID)
                      .IsUnique();

                //  Key
                entity.Property(x => x.Key)
                      .HasColumnName("Key")
                      .HasColumnType("nvarchar(128)")
                      .IsRequired()
                      .HasMaxLength(128);

                entity.HasIndex(e => e.Key)
                      .IsUnique();

                //  Value
                entity.Property(x => x.Value)
                      .HasColumnName("Value")
                      .HasColumnType("nvarchar(max)")
                      .IsRequired();

            });

        }
    }
}
