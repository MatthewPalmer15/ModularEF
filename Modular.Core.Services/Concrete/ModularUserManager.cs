using Microsoft.AspNetCore.Identity;
using Modular.Core.Entities;
using Modular.Core.Identity;

namespace Modular.Core.Services.Identity
{

    public class ModularIdentityManager : IModularIdentityManager
    {

        public UserManager<ApplicationUser> UserManager { get; }

        public RoleManager<ApplicationRole> RoleManager { get; }


        public ModularIdentityManager(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        /// <summary>
        /// Creates a new application user. Returns null if it was not successful.
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public async Task<IdentityResult> CreateIdentityAsync(Contact contact, string username, string password, bool createIfNull, params string[] roles)
        {
            ApplicationUser applicationUser = new ApplicationUser()
            {
                UserName = username,
                Email = contact.Email,
                ContactId = contact.Id,
                Contact = contact,
            };

            var createUserResult = await UserManager.CreateAsync(applicationUser, password);
            if (!createUserResult.Succeeded)
            {
                return IdentityResult.Failed(createUserResult.Errors.ToArray());
            }

            foreach (string role in roles)
            {
                var createRoleResult = await applicationUser.AssignRoleAsync(UserManager, RoleManager, role, createIfNull);
                if (!createRoleResult.Succeeded)
                {
                    return IdentityResult.Failed(createRoleResult.Errors.ToArray());
                }
            }

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> AssignRolesAsync(ApplicationUser applicationUser, bool createIfNull, params string[] roles)
        {
            foreach (string role in roles)
            {
                var result = await applicationUser.AssignRoleAsync(UserManager, RoleManager, role, createIfNull);
                if (!result.Succeeded) 
                {
                    return IdentityResult.Failed(result.Errors.ToArray());
                }
            }

            return IdentityResult.Success;
        }

        //public string GenerateApiToken()
        //{
        //    Guid UUID = Guid.NewGuid();
        //    string apiToken = UUID.ToString().Replace("-", "");
        //    return UUID.ToString();
        //}

    }
}
