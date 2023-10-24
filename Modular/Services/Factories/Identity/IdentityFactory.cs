using Microsoft.EntityFrameworkCore;
using Modular.Core.Identity;
using Modular.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Models.Entity
{
    public static class IdentityFactory
    {

        public static ApplicationUser Construct()
        {
            return new ApplicationUser();
        }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ApplicationUser>()
            .ToTable("ApplicationUser")
            .HasKey(x => x.Id);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(x => x.Contact)
                .WithOne()
                .HasForeignKey<ApplicationUser>(x => x.ContactID);


            modelBuilder.Entity<ApplicationUser>()
                .Property(x => x.ContactID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ApplicationUser>()
                .HasIndex(e => e.ContactID)
                .IsUnique();

        }
    }
}
