using Modular.Core.Entities.Concrete;
using Modular.Core.Interfaces;

namespace Modular.Core.Entities.Abstract
{
    public interface ICompany : IBaseEntity<Guid>
    {

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? RegistrationNumber { get; set; }

        public Guid OwnerId { get; set; }

        public Contact Owner { get; set; }

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

    }
}
