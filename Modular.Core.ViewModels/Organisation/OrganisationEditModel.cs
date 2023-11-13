using Microsoft.EntityFrameworkCore;
using Modular.Core.Helpers.Types;
using System.ComponentModel.DataAnnotations;

namespace Modular.Core.ViewModels.Organisation
{
    public class OrganisationEditModel
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
        public IEnumerable<Modular.Core.Models.Entity.Contact>? Contacts { get; set; }

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
        public IEnumerable<Modular.Core.Models.Location.Country>? Countries { get; set; }

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

        public OrganisationEditModel()
        {
            Name = string.Empty;
            Description = string.Empty;
            RegistrationNumber = string.Empty;
            OwnerId = null;
            AddressLine1 = string.Empty;
            AddressLine2 = string.Empty;
            AddressLine3 = string.Empty;
            AddressCity = string.Empty;
            AddressCounty = string.Empty;
            AddressCountryId = null;
            Email = string.Empty;
            Phone = string.Empty;
            Website = string.Empty;
            Status = StatusType.Active;
        }

        public OrganisationEditModel(ModularDbContext context)
        {
            Name = string.Empty;
            Description = string.Empty;
            RegistrationNumber = string.Empty;
            OwnerId = null;
            AddressLine1 = string.Empty;
            AddressLine2 = string.Empty;
            AddressLine3 = string.Empty;
            AddressCity = string.Empty;
            AddressCounty = string.Empty;
            AddressCountryId = null;
            Email = string.Empty;
            Phone = string.Empty;
            Website = string.Empty;
            Status = StatusType.Active;

            Contacts = context.Contacts.AsNoTracking().ToList();
            Countries = context.Countries.AsNoTracking().ToList();
        }

        public OrganisationEditModel(ModularDbContext context, Modular.Core.Models.Entity.Organisation organisation)
        {
            Name = organisation.Name;
            Description = organisation.Description;
            RegistrationNumber = organisation.RegistrationNumber;
            OwnerId = organisation.OwnerId;
            AddressLine1 = organisation.AddressLine1;
            AddressLine2 = organisation.AddressLine2;
            AddressLine3 = organisation.AddressLine3;
            AddressCity = organisation.AddressCity;
            AddressCounty = organisation.AddressCounty;
            AddressCountryId = organisation.AddressCountryId;
            Email = organisation.Email;
            Phone = organisation.Phone;
            Website = organisation.Website;
            Status = organisation.Status;

            Contacts = context.Contacts.AsNoTracking().ToList();
            Countries = context.Countries.AsNoTracking().ToList();
        }

        #endregion
    }
}
