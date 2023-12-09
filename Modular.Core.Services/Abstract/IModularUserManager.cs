using Microsoft.AspNetCore.Identity;
using Modular.Core.Entities;
using Modular.Core.Identity;

namespace Modular.Core.Services.Identity
{

    public interface IModularIdentityManager
    {

        UserManager<ApplicationUser> UserManager { get; }

        RoleManager<ApplicationRole> RoleManager { get; }


        /// <summary>
        /// Creates a new application user. Returns null if it was not successful.
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public Task<IdentityResult> CreateIdentityAsync(Contact contact, string username, string password, bool createIfNull, params string[] roles);

        public Task<IdentityResult> AssignRolesAsync(ApplicationUser applicationUser, bool createIfNull, params string[] roles);

    }
}
