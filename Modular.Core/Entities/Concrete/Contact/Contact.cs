#nullable disable

using Modular.Core.Entities.Abstract;
using Modular.Core.Interfaces;

namespace Modular.Core.Entities.Concrete
{
    public class Contact : BaseEntity<Guid>, IContact, IAuditable
    {

        public IContact.TitleType? Title { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public IContact.GenderType? Gender { get; set; }

        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? AddressLine3 { get; set; }

        public string? AddressCity { get; set; }

        public string? AddressCounty { get; set; }

        public Guid? AddressCountryId { get; set; }

        public Country? AddressCountry { get; set; }

        public string? AddressPostcode { get; set; }

        public string Email { get; set; }

        public string? Phone { get; set; }

        public string? Mobile { get; set; }

        public Guid? CompanyId { get; set; }

        public Company? Company { get; set; }

        public bool IsVerified { get; set; }

        public bool IsBanned { get; set; }

    }
}
