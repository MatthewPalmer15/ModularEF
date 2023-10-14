using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Modular.Core.Identity;

namespace Modular.Core
{ 
    public class ModularIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {

        #region "  Constructors  "

        public ModularIdentityDbContext(DbContextOptions<ModularIdentityDbContext> options)
            : base(options)
        {
        }

        #endregion

    }
}
