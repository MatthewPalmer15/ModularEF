using Modular.Core.Helpers.Types;
using Modular.Core.Models.Location;

#nullable disable

namespace Modular.Core.Models.Entity
{
    public class Organisation : BaseEntity
    {

        #region "  Properties  "

        public string Name { get; set; }

        public string Description { get; set; }

        public string RegistrationNumber { get; set; }

        public Guid ContactId { get; set; }

        public virtual Contact Contact { get; set; }

        public string AddressLine1 { get; set; } 

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string AddressCity { get; set; }

        public string AddressCounty { get; set; }

        public Guid AddressCountryID { get; set; }

        public virtual Country AddressCountry { get; set; }

        public string AddressPostcode { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public string Website { get; set; }

        public StatusType Status { get; set; }

        #endregion

    }
}
