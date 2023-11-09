﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Modular.Core.Identity;
using Modular.Core.Models.Audit;
using Modular.Core.Models.Config;
using Modular.Core.Models.Entity;
using Modular.Core.Models.Location;
using Modular.Core.Models.Misc;
using Modular.Core.Services.Factories.Audit;
using Modular.Core.Services.Factories.Config;
using Modular.Core.Services.Factories.Entity;
using Modular.Core.Services.Factories.Identity;
using Modular.Core.Services.Factories.Location;
using Modular.Core.Services.Factories.Misc;

namespace Modular.Core
{
    public class ModularDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {

        #region "  Constructors  "

        public ModularDbContext()
        {
        }

        public ModularDbContext(DbContextOptions<ModularDbContext> options) : base(options)
        {
        }

        #endregion

        #region "  DbSets  "

        public virtual DbSet<AuditLog> AuditLogs { get; set; }

        public virtual DbSet<Configuration> Configurations { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<Organisation> Organisations { get; set; }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Occupation> Occupations { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");
            //base.OnModelCreating(modelBuilder);

            //  Audit
            AuditFactory.OnModelCreating(modelBuilder);

            //  Config
            ConfigurationFactory.OnModelCreating(modelBuilder);

            //  Entity
            ContactFactory.OnModelCreating(modelBuilder);
            OrganisationFactory.OnModelCreating(modelBuilder);

            //  Identity
            IdentityFactory.OnModelCreating(modelBuilder);

            //  Location
            CountryFactory.OnModelCreating(modelBuilder);

            //  Misc
            DepartmentFactory.OnModelCreating(modelBuilder);
            OccupationFactory.OnModelCreating(modelBuilder);

        }

    }
}
