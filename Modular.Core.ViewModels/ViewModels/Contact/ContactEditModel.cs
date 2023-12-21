#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Modular.Core.ViewModels.Contact
{
    public class ContactEditModel
    {

        [Display(Name = "Forename")]
        public string Forename { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateOnly DateOfBirth { get; set; }

        [Display(Name = "Address Line 1")]
        public string? AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; }

        [Display(Name = "Address Line 3")]
        public string? AddressLine3 { get; set; }

        [Display(Name = "City")]
        public string? AddressCity { get; set; }

        [Display(Name = "County")]
        public string? AddressCounty { get; set; }

        [Display(Name = "Country")]
        public Guid? AddressCountryId { get; set; }
        public IEnumerable<Entities.Concrete.Country>? Countries { get; set; }

        [Display(Name = "Postcode")]
        public string? AddressPostcode { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string? Phone { get; set; }

        [Display(Name = "Mobile")]
        public string? Mobile { get; set; }

        public Guid? OrganisationId { get; set; }
        public IEnumerable<Entities.Concrete.Company>? Companies { get; set; }

        [Display(Name = "Is Verified")]
        public bool IsVerified { get; set; }

        [Display(Name = "Is Banned")]
        public bool IsBanned { get; set; }

    }
}
