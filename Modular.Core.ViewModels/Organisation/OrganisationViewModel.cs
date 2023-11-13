using Modular.Core;
using Modular.Core.Helpers.Types;
using Modular.Core.Models.Entity;
using Modular.Core.Models.Location;
using Modular.Core.Models.Misc;
using System.ComponentModel.DataAnnotations;
using static Modular.Core.Models.Entity.Contact;

namespace matthewpalmer.dev.Models.Contact
{
    public class AllOrganisationViewModel
    {

        #region "  Properties  "

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "RegistrationNumber")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Owner")]
        public Guid? OwnerId { get; set; }

        [Display(Name = "Owner")]
        public Modular.Core.Models.Entity.Contact? Owner { get; set; }

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
        public Modular.Core.Models.Location.Country? AddressCountry { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Website")]
        public string Website { get; set; }

        [Display(Name = "Status")]
        public StatusType Status { get; set; }

        #endregion

        #region "  Constructors  "

        public AllOrganisationViewModel(Modular.Core.Models.Entity.Organisation organisation)
        {
            Name = organisation.Name;
            Description = organisation.Description;
            RegistrationNumber = organisation.RegistrationNumber;
            OwnerId = organisation.OwnerId;
            Owner = organisation.Owner;
            AddressLine1 = organisation.AddressLine1;
            AddressLine2 = organisation.AddressLine2;
            AddressLine3 = organisation.AddressLine3;
            AddressCity = organisation.AddressCity;
            AddressCounty = organisation.AddressCounty;
            AddressCountryId = organisation.AddressCountryId;
            AddressCountry = organisation.AddressCountry;
            Email = organisation.Email;
            Phone = organisation.Phone;
            Website = organisation.Website;
            Status = organisation.Status;
        }

        #endregion

    }
}
