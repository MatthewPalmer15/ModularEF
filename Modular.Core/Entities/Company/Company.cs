#nullable disable

using Modular.Core.Helpers.Types;
using Modular.Core.Interfaces;

namespace Modular.Core.Entities
{
    public class Company : BaseEntity<Guid>, IAuditable
    {

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? RegistrationNumber { get; set; }

        public Guid OwnerId { get; set; }

        public virtual Contact Owner { get; set; }

        public string AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? AddressLine3 { get; set; }

        public string AddressCity { get; set; }

        public string AddressCounty { get; set; }

        public Guid? AddressCountryId { get; set; }

        public Country? AddressCountry { get; set; }

        public string AddressPostcode { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string? Website { get; set; }

        public StatusType Status { get; set; }

    }
}
