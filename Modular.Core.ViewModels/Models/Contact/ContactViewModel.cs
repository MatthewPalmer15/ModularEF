#nullable disable

namespace Modular.Core.ViewModels.Entity
{
    public class ContactViewModel
    {

        public Guid Id { get; set; }

        public Models.Entity.Contact.TitleType? Title { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public Models.Entity.Contact.GenderType? Gender { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string AddressCity { get; set; }

        public string AddressCounty { get; set; }

        public Guid? AddressCountryId { get; set; }

        public Models.Location.Country? AddressCountry { get; set; }

        public string AddressPostcode { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public Guid? OrganisationId { get; set; }
        public Models.Entity.Organisation? Organisation { get; set; }

        public bool IsVerified { get; set; }

        public bool IsBanned { get; set; }

    }
}
