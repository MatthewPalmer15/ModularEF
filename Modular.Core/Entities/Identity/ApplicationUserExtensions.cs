using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Modular.Core.Identity
{
    public static class ApplicationUserExtensions
    {

        //  Roles
        public static async Task<IdentityResult> AssignRoleAsync(this ApplicationUser user, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, string roleName, bool createIfNull = false)
        {
            //  Find role, and create it if needed (and allowed).
            ApplicationRole? applicationRole = roleManager.FindByNameAsync(roleName).Result;
            if (applicationRole == null && createIfNull)
            {
                ApplicationRole createdApplicationRole = new ApplicationRole { Name = roleName };
                var createRoleResult = await roleManager.CreateAsync(createdApplicationRole);
                if (!createRoleResult.Succeeded)
                {
                    return IdentityResult.Failed(createRoleResult.Errors.ToArray());
                }
            }

            var addRoleResult = await userManager.AddToRoleAsync(user, roleName);
            if (!addRoleResult.Succeeded)
            {
                return IdentityResult.Failed(addRoleResult.Errors.ToArray());
            }

            return IdentityResult.Success;
        }

        public static async Task<IdentityResult> AssignRolesAsync(this ApplicationUser user, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, string[] roleNames, bool createIfNull = false)
        {
            foreach (string roleName in roleNames)
            {
                ApplicationRole? applicationRole = roleManager.FindByNameAsync(roleName).Result;
                if (applicationRole == null && createIfNull)
                {
                    ApplicationRole createdApplicationRole = new ApplicationRole { Name = roleName };
                    var createRoleResult = await roleManager.CreateAsync(createdApplicationRole);
                    if (!createRoleResult.Succeeded)
                    {
                        return IdentityResult.Failed(createRoleResult.Errors.ToArray());
                    }
                }

                var addRoleResult = await userManager.AddToRoleAsync(user, roleName);
                if (!addRoleResult.Succeeded)
                {
                    return IdentityResult.Failed(addRoleResult.Errors.ToArray());
                }
            }

            return IdentityResult.Success;
        }

        public static async Task<IdentityResult> RevokeRoleAsync(this ApplicationUser user, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, string roleName)
        {
            var result = await userManager.RemoveFromRoleAsync(user, roleName);
            return result;
        }


        //  Claims
        public static async Task<bool> AssignClaimAsync(this ApplicationUser user, UserManager<ApplicationUser> userManager, string claimType, string claimValue)
        {
            bool isSuccessful = false;

            var newClaim = new Claim(claimType, claimValue);

            bool claimExists = false;

            IList<Claim> allUserClaims = await userManager.GetClaimsAsync(user);
            foreach (Claim claim in allUserClaims)
            {
                if (claim.Type.Trim().ToLower() == claimType.Trim().ToLower())
                {
                    var result = userManager.ReplaceClaimAsync(user, claim, newClaim).Result;
                    isSuccessful = result.Succeeded;
                    claimExists = true;
                    break;
                }
            }

            if (!claimExists)
            {
                var result = await userManager.AddClaimAsync(user, newClaim);
                isSuccessful = result.Succeeded;
            }

            return isSuccessful;
        }


        public static async Task<bool> AssignClaimsAsync(this ApplicationUser user, UserManager<ApplicationUser> userManager, List<KeyValuePair<string, string>> items)
        {
            List<bool> isSuccessful = new List<bool>();

            foreach (KeyValuePair<string, string> item in items)
            {

                var newClaim = new Claim(item.Key, item.Value);

                bool claimExists = false;

                IList<Claim> allUserClaims = await userManager.GetClaimsAsync(user);
                foreach (Claim claim in allUserClaims)
                {
                    if (claim.Type.Trim().ToLower() == item.Key.Trim().ToLower())
                    {
                        var result = userManager.ReplaceClaimAsync(user, claim, newClaim).Result;
                        isSuccessful.Add(result.Succeeded);
                        claimExists = true;
                        break;
                    }
                }

                if (!claimExists)
                {
                    var result = await userManager.AddClaimAsync(user, newClaim);
                    isSuccessful.Add(result.Succeeded);
                }


            }

            return !isSuccessful.Contains(false);
        }

    }


}
