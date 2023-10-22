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

        public ApplicationUser(Contact contact, string userName, string password)
        {
            this.ContactID = contact.ID;
            this.Contact = contact;
            this.UserName = userName;
            this.Email = contact.Email;
            this.PhoneNumber = contact.Mobile;
            this.PasswordHash = password;
        }

        #region "  Properties  "

        public Guid ContactID { get; set; }

        public virtual Contact Contact { get; set; }


        #endregion

    }
}
