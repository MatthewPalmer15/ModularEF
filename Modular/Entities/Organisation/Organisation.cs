using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modular.Core.Helpers;

namespace Modular.Core.Organisation
{
    public class Organisation : BaseEntity
    {

        #region "  Properties  "

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string RegistrationNumber { get; set; } = string.Empty;

        public Guid OwnerID { get; set; } = Guid.Empty;

        public virtual Contact Owner { get; set; }

        public string AddressLine1 { get; set; } = string.Empty;

        public string AddressLine2 { get; set; } = string.Empty;

        public string AddressLine3 { get; set; } = string.Empty;

        public string AddressCity { get; set; } = string.Empty;

        public string AddressCounty { get; set; } = string.Empty;

        public Guid AddressCountryID { get; set; } = Guid.Empty;

        public string AddressPostcode { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Telephone { get; set; } = string.Empty;

        public string Website { get; set; } = string.Empty;

        public MiscUtils.StatusType Status { get; set; } = MiscUtils.StatusType.Active;

        #endregion

    }
}
