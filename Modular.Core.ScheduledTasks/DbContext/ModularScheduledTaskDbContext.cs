using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Modular.Core.Entities.Abstract;
using Modular.Core.Entities.Concrete;
using Modular.Core.Interfaces;
using System.Security.Claims;

namespace Modular.Core
{

    /// <summary>
    /// Modular DB Context without ASP.NET Identity
    /// </summary>
    public class ModularScheduledTaskDbContext : DbContext
    {

        #region "  Constructors  "

        public ModularScheduledTaskDbContext()
        {
        }

        public ModularScheduledTaskDbContext(DbContextOptions<ModularDbContext> options) : base(options)
        {        
        }

        #endregion

        #region "  DbSets  "

        public virtual DbSet<ScheduledTask> ScheduledTasks { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");
            modelBuilder.HasDefaultSchema("dbo");
        }

    }
}
