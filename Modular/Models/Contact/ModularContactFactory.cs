using Microsoft.EntityFrameworkCore;
using Modular.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Entity
{
    public static class ContactFactory
    {

        public static Contact Construct()
        {
            return new Contact();
        }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("tbl_Contact");

                entity.HasKey(e => e.ID)
                      .IsClustered(false);


                entity.Property(e => e.ID)
                      .HasColumnName("ID")
                      .ValueGeneratedNever()
                      .IsRequired();


                entity.Property(x => x.Forename)
                      .HasColumnName("Forename")
                      .IsRequired()
                      .HasMaxLength(128);



            });

        }
    }
}
