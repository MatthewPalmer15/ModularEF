#nullable disable

namespace Modular.Core.ViewModels.Contact
{
    public class ContactViewModel
    {

        public Guid Id { get; set; }

        public Entities.Contact.TitleType? Title { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public Entities.Contact.GenderType? Gender { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string AddressCity { get; set; }

        public string AddressCounty { get; set; }

        public Guid? AddressCountryId { get; set; }

        public Entities.Country? AddressCountry { get; set; }

        public string AddressPostcode { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public Guid? CompanyId { get; set; }

        public Entities.Company? Company { get; set; }

        public bool IsVerified { get; set; }

        public bool IsBanned { get; set; }

    }
}
