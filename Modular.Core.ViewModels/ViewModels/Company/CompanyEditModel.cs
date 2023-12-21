#nullable disable

using Modular.Core.Helpers.Types;
using System.ComponentModel.DataAnnotations;

namespace Modular.Core.ViewModels.Company
{
    public class CompanyEditModel
    {

        public Guid Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "RegistrationNumber")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Owner")]
        public Guid OwnerId { get; set; }
        public IEnumerable<Entities.Concrete.Contact>? Contacts { get; set; }

        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Display(Name = "Address Line 3")]
        public string AddressLine3 { get; set; }

        [Display(Name = "City")]
        public string AddressCity { get; set; }

        [Display(Name = "County")]
        public string AddressCounty { get; set; }

        [Display(Name = "Country")]
        public Guid? AddressCountryId { get; set; }
        public IEnumerable<Entities.Concrete.Country>? Countries { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Website")]
        public string Website { get; set; }

    }
}
