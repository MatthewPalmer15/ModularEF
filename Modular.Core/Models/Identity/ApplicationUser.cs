using Microsoft.AspNetCore.Identity;
using Modular.Core.Models.Entity;

namespace Modular.Core.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
        }

        public ApplicationUser(Contact contact, string userName)
        {
            this.Id = contact.Id.ToString();
            //this.ContactID = contact.ID;
            //this.Contact = contact;
            this.UserName = userName;
            this.Email = contact.Email;
            this.PhoneNumber = contact.Mobile;
            this.IsStaff = false;
            this.IsAdmin = false;
        }

        public ApplicationUser(Contact contact, string userName, bool isStaff, bool isAdmin)
        {
            this.Id = contact.Id.ToString();
            this.ContactID = contact.Id;
            this.Contact = contact;
            this.UserName = userName;
            this.Email = contact.Email;
            this.PhoneNumber = contact.Mobile;
            this.IsStaff = isStaff;
            this.IsAdmin = isAdmin;
        }

        #region "  Properties  "

         public Guid ContactID { get; set; }
         
         public virtual Contact Contact { get; set; }

        public bool IsStaff { get; set; }

        public bool IsAdmin { get; set; }

        #endregion

    }
}
