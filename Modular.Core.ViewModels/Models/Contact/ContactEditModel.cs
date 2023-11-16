using Modular.Core;
using Modular.Core.Models.Entity;
using Modular.Core.Models.Misc;
using System.ComponentModel.DataAnnotations;

namespace Modular.Core.ViewModels.Entity
{
    public class ContactEditModel
    {

        #region "  Properties  "

        [Display(Name = "Forename")]
        public string Forename { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateOnly DateOfBirth { get; set; }

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

        [Display(Name = "Postcode")]
        public string AddressPostcode { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        public Guid? OccupationId { get; set; }
        public IEnumerable<Occupation>? Occupations { get; set; }

        public Guid? DepartmentId { get; set; }
        public IEnumerable<Department>? Departments { get; set; }

        public Guid? OrganisationId { get; set; }
        public IEnumerable<Modular.Core.Models.Entity.Organisation>? Organisations { get; set; }

        [Display(Name = "Is Verified")]
        public bool IsVerified { get; set; }

        [Display(Name = "Is Banned")]
        public bool IsBanned { get; set; }

        #endregion

        #region "  Constructors  "

        public ContactEditModel()
        {
            Forename = string.Empty;
            Surname = string.Empty;
            DateOfBirth = DateOnly.MinValue;
            AddressLine1 = string.Empty;
            AddressLine2 = string.Empty;
            AddressLine3 = string.Empty;
            AddressCity = string.Empty;
            AddressCounty = string.Empty;
            AddressPostcode = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            Mobile = string.Empty;
            IsVerified = false;
            IsBanned = false;
        }

        public ContactEditModel(ModularDbContext context)
        {
            Forename = string.Empty;
            Surname = string.Empty;
            DateOfBirth = DateOnly.MinValue;
            AddressLine1 = string.Empty;
            AddressLine2 = string.Empty;
            AddressLine3 = string.Empty;
            AddressCity = string.Empty;
            AddressCounty = string.Empty;
            AddressPostcode = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            Mobile = string.Empty;
            IsVerified = false;
            IsBanned = false;

            Countries = context.Countries.ToList();
            Departments = context.Departments.ToList();
            Occupations = context.Occupations.ToList();
            Organisations = context.Organisations.ToList();
        }

        public ContactEditModel(ModularDbContext context, Models.Entity.Contact contact)
        {
            Forename = contact.Forename;
            Surname = contact.Surname;
            DateOfBirth = DateOnly.FromDateTime(contact.DateOfBirth);
            AddressLine1 = contact.AddressLine1;
            AddressLine2 = contact.AddressLine2;
            AddressLine3 = contact.AddressLine3;
            AddressCity = contact.AddressCity;
            AddressCounty = contact.AddressCounty;
            AddressCountryId = contact.AddressCountryId;
            AddressPostcode = contact.AddressPostcode;
            Email = contact.Email;
            Phone = contact.Phone;
            Mobile = contact.Mobile;
            OccupationId = contact.OccupationId;
            DepartmentId = contact.DepartmentId;
            OrganisationId = contact.OrganisationId;
            IsBanned = contact.IsBanned;
            IsVerified = contact.IsVerified;

            Countries = context.Countries.ToList();
            Departments = context.Departments.ToList();
            Occupations = context.Occupations.ToList();
            Organisations = context.Organisations.ToList();
        }

        #endregion

        #region "  Public Methods  "

        public Contact Convert()
        {
            return new Contact()
            {
                Forename = Forename,
                Surname = Surname,
                DateOfBirth = DateOfBirth.ToDateTime(new TimeOnly(0)),
                AddressLine1 = AddressLine1,
                AddressLine2 = AddressLine2,
                AddressLine3 = AddressLine3,
                AddressCity = AddressCity,
                AddressCounty = AddressCounty,
                AddressCountryId = AddressCountryId,
                AddressPostcode = AddressPostcode,
                Email = Email,
                Phone = Phone,
                Mobile = Mobile,
                OccupationId = OccupationId,
                DepartmentId = DepartmentId,
                OrganisationId = OrganisationId,
                IsVerified = IsVerified,
                IsBanned = IsBanned
            };
        }


        #endregion
    }
}
