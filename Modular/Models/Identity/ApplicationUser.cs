using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Modular.Core.Entity;

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

        public Guid ContactID { get; set; }

        public virtual Contact Contact { get; set; }


        #endregion


        /// services.AddIdentity<ApplicationUser, ApplicationRole>()
        /// .AddEntityFrameworkStores<ApplicationDbContext>()
        /// .AddDefaultTokenProviders();

    }
}
