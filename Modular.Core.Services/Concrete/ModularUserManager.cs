using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Modular.Core.Entities;
using Modular.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<ApplicationUser?> CreateIdentityAsync(Contact contact, string username, string password, params string[] roles)
        {
            ApplicationUser applicationUser = new ApplicationUser()
            {
                UserName = username,
                Email = contact.Email,
                ContactId = contact.Id,
                Contact = contact,
            };

            var result = await UserManager.CreateAsync(applicationUser, password);
            if (result.Succeeded)
            {
                foreach (string role in roles)
                {
                    await applicationUser.AssignRoleAsync(UserManager, RoleManager, role);
                }
                return applicationUser;
            }
            else
            {
                return null;
            }
        }

    }
}
