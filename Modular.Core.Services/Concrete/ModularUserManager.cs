using Microsoft.AspNetCore.Identity;
using Modular.Core.Entities;
using Modular.Core.Identity;
using System.Security.Claims;

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

        #region "  Users  "

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

            var createRolesResult = await AssignRolesAsync(applicationUser, createIfNull, roles);
            if (!createRolesResult.Succeeded)
            {
                return IdentityResult.Failed(createRolesResult.Errors.ToArray());
            }
            return IdentityResult.Success;
        }

        #endregion

        #region "  Roles  "

        /// <summary>
        /// Adds role(s) to a user.
        /// </summary>
        /// <param name="applicationUser"></param>
        /// <param name="createIfNull"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public async Task<IdentityResult> AssignRolesAsync(ApplicationUser applicationUser, bool createIfNull, params string[] roles)
        {
            foreach (string role in roles)
            {
                //  Get role, and if it does not exist, create it if allowed.
                bool roleExists = await RoleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    if (createIfNull)
                    {
                        ApplicationRole newApplicationRole = new ApplicationRole { Name = role };
                        var createRoleResult = await RoleManager.CreateAsync(newApplicationRole);
                        if (!createRoleResult.Succeeded)
                        {
                            return IdentityResult.Failed(createRoleResult.Errors.ToArray());
                        }
                    }
                    else
                    {
                        return IdentityResult.Failed(new IdentityError() { Code = "RoleNotFound", Description = "Role was not found, and could not be created." });
                    }
                }

                //  Assign role to user
                var addRoleResult = await UserManager.AddToRoleAsync(applicationUser, role);
                if (!addRoleResult.Succeeded)
                {
                    return IdentityResult.Failed(addRoleResult.Errors.ToArray());
                }


            }

            return IdentityResult.Success;
        }

        /// <summary>
        /// Removes role(s) from a user.
        /// </summary>
        /// <param name="applicationUser"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public async Task<IdentityResult> RevokeRolesAsync(ApplicationUser applicationUser, params string[] roles)
        {
            foreach (string role in roles)
            {
                bool roleExists = await RoleManager.RoleExistsAsync(role);
                if (roleExists)
                {
                    var removeRoleResult = await UserManager.RemoveFromRoleAsync(applicationUser, role);
                    if (!removeRoleResult.Succeeded)
                    {
                        return IdentityResult.Failed(removeRoleResult.Errors.ToArray());
                    }
                }
            }

            return IdentityResult.Success;
        }


        #endregion

        #region "  Claims  "

        /// <summary>
        /// Adds Claim(s) to a user.
        /// </summary>
        /// <param name="applicationUser"></param>
        /// <param name="claims"></param>
        /// <returns></returns>
        public async Task<IdentityResult> AssignClaimsAsync(ApplicationUser applicationUser, params Claim[] claims)
        {
            IList<Claim> userClaims = await UserManager.GetClaimsAsync(applicationUser);

            foreach (Claim claim in claims)
            {
                Claim? existingClaim = userClaims.FirstOrDefault(x => x.Type == claim.Type);

                if (existingClaim != null)
                {
                    var replaceClaimResult = await UserManager.ReplaceClaimAsync(applicationUser, existingClaim, claim);
                    if (!replaceClaimResult.Succeeded)
                    {
                        return IdentityResult.Failed(replaceClaimResult.Errors.ToArray());
                    }

                }
                else
                {
                    var addClaimResult = await UserManager.AddClaimAsync(applicationUser, claim);
                    if (!addClaimResult.Succeeded)
                    {
                        return IdentityResult.Failed(addClaimResult.Errors.ToArray());
                    }

                }
            }

            return IdentityResult.Success;
        }


        /// <summary>
        /// Removes Claim(s) from a user.
        /// </summary>
        /// <param name="applicationUser"></param>
        /// <param name="claims"></param>
        /// <returns></returns>
        public async Task<IdentityResult> RevokeClaimsAsync(ApplicationUser applicationUser, params Claim[] claims)
        {
            IList<Claim> userClaims = await UserManager.GetClaimsAsync(applicationUser);
            foreach (Claim claim in claims)
            {
                Claim? existingClaim = userClaims.FirstOrDefault(x => x.Type == claim.Type);

                if (existingClaim != null)
                {
                    var replaceClaimResult = await UserManager.RemoveClaimAsync(applicationUser, existingClaim);
                    if (!replaceClaimResult.Succeeded)
                    {
                        return IdentityResult.Failed(replaceClaimResult.Errors.ToArray());
                    }

                }
            }

            return IdentityResult.Success;
        }

        #endregion

        #region "  Tokens  "

        public async Task<IdentityResult> AssignTokenAsync(ApplicationUser applicationUser, string loginProvider, string tokenName, string? tokenValue)
        {
            var result = await UserManager.SetAuthenticationTokenAsync(applicationUser, loginProvider, tokenName, tokenValue);
            return result;
        }

        public async Task<IdentityResult> RevokeTokenAsync(ApplicationUser applicationUser, string loginProvider, string tokenName)
        {
            var result = await UserManager.RemoveAuthenticationTokenAsync(applicationUser, loginProvider, tokenName);
            return result;
        }

        #endregion

    }


}
