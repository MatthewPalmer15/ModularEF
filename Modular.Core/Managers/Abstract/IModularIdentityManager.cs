using Microsoft.AspNetCore.Identity;
using Modular.Core.Entities;
using Modular.Core.Identity;
using System.Security.Claims;

namespace Modular.Core.Identity
{

    public interface IModularIdentityManager
    {

        UserManager<ApplicationUser> UserManager { get; }

        RoleManager<ApplicationRole> RoleManager { get; }


        public Task<IdentityResult> CreateIdentityAsync(Contact contact, string username, string password, bool createIfNull, params string[] roles);

        public Task<IdentityResult> AssignRolesAsync(ApplicationUser applicationUser, bool createIfNull, params string[] roles);

        public Task<IdentityResult> RevokeRolesAsync(ApplicationUser applicationUser, params string[] roles);

        public Task<IdentityResult> AssignClaimsAsync(ApplicationUser applicationUser, params Claim[] claims);

        public Task<IdentityResult> RevokeClaimsAsync(ApplicationUser applicationUser, params Claim[] claims);

        public Task<IdentityResult> AssignTokenAsync(ApplicationUser applicationUser, string loginProvider, string tokenName, string? tokenValue);

        public Task<IdentityResult> RevokeTokenAsync(ApplicationUser applicationUser, string loginProvider, string tokenName);
    }
}
