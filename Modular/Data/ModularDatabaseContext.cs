using Microsoft.EntityFrameworkCore;

namespace Modular.Core
{
    public class ModularCoreDbContext : DbContext
    {

        #region "  Constructors  "

        public ModularCoreDbContext(DbContextOptions<ModularCoreDbContext> options) : base(options)
        {
        }

        #endregion

        #region "  DbSets  "

        // public DbSet<Modular.Core.Entities.User> Users { get; set; }

        #endregion

    }
}
