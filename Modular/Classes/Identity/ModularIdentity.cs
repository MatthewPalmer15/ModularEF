using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Modular.Core.Identity
{
    public class ApplicationUser : IdentityUser
    {

        #region "  Constructors  "

        public ApplicationUser()
        {
        }

        #endregion

        #region "  Properties  "

        public string FirstName { get; set; }
        public string LastName { get; set; }

        #endregion


        /// services.AddIdentity<ApplicationUser, ApplicationRole>()
        /// .AddEntityFrameworkStores<ApplicationDbContext>()
        /// .AddDefaultTokenProviders();

    }
}
