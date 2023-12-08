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
        public Task<ApplicationUser?> CreateIdentityAsync(Contact contact, string username, string password, params string[] roles);

    }
}
