using Microsoft.EntityFrameworkCore;
using Modular.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Entity
{
    public static class OrganisationFactory
    {

        public static Organisation Construct()
        {
            return new Organisation();
        }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organisation>(entity =>
            {
                entity.ToTable("tbl_Organisation");
            });

        }
    }
}
