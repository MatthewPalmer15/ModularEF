using Microsoft.AspNetCore.Identity;
using Modular.Core.Models.Entity;

#nullable disable

namespace Modular.Core.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
        }

        #region "  Properties  "

        public DateTime CreatedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public Guid ModifiedBy { get; set; }

        public Guid ContactId { get; set; }
         
        public virtual Contact Contact { get; set; }

        public bool IsStaff { get; set; }

        public bool IsAdmin { get; set; }

        public Guid ProfileId { get; set; }

        //public virtual ApplicationProfile Profile { get; set; }

        #endregion

        public void Update()
        {
            ModifiedDate = DateTime.Now;
            ModifiedBy = Guid.Empty;
        }
    }
}
