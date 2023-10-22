using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Modular.Core.Entity;
using System.Text.Json.Serialization;

namespace Modular.Core.Identity
{
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser(Contact contact, string userName, string password)
        {
            this.Id = contact.ID.ToString();
            this.ContactID = contact.ID;
            this.Contact = contact;
            this.UserName = userName;
            this.Email = contact.Email;
            this.PhoneNumber = contact.Mobile;
            this.PasswordHash = password;
        }

        #region "  Properties  "

        [JsonIgnore]
        public Guid ContactID { get; set; }

        public virtual Contact Contact { get; set; }

        public bool IsStaff { get; set; }

        public bool IsAdmin { get; set; }

        // public virtual ICollection<Organisation> Organisations { get; set; }


        #endregion

    }
}
