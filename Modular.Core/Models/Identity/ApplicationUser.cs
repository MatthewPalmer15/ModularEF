using Microsoft.AspNetCore.Identity;
using Modular.Core.Models.Entity;

#nullable disable

namespace Modular.Core.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {

        #region "  Properties  "

        public Guid ContactId { get; set; }

        public Contact Contact { get; set; }

        public bool IsStaff { get; set; }

        public bool IsAdmin { get; set; }

        public Guid ProfileId { get; set; }

        //public virtual ApplicationProfile Profile { get; set; }

        #endregion
    }
}
