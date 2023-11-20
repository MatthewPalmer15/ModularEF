using Modular.Core.Models.Misc;

namespace Modular.Core.ViewModels.Entity
{
    public class ContactViewModel
    {

        #region "  Properties  "

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

        public Guid? OccupationId { get; set; }

        public Occupation? Occupation { get; set; }

        public Guid? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public Guid? OrganisationId { get; set; }
        public Modular.Core.Models.Entity.Organisation? Organisation { get; set; }

        public bool IsVerified { get; set; }

        public bool IsBanned { get; set; }

        #endregion

        #region "  Constructors  "

        public ContactViewModel(Models.Entity.Contact contact)
        {
            Title = contact.Title;
            Forename = contact.Forename;
            Surname = contact.Surname;
            DateOfBirth = DateOnly.FromDateTime(contact.DateOfBirth);
            Gender = contact.Gender;
            AddressLine1 = contact.AddressLine1;
            AddressLine2 = contact.AddressLine2;
            AddressLine3 = contact.AddressLine3;
            AddressCity = contact.AddressCity;
            AddressCounty = contact.AddressCounty;
            AddressCountryId = contact.AddressCountryId;
            AddressCountry = contact.AddressCountry;
            AddressPostcode = contact.AddressPostcode;
            Email = contact.Email;
            Phone = contact.Phone;
            Mobile = contact.Mobile;
            OccupationId = contact.OccupationId;
            Occupation = contact.Occupation;
            DepartmentId = contact.DepartmentId;
            Department = contact.Department;
            OrganisationId = contact.OrganisationId;
            Organisation = contact.Organisation;
            IsBanned = contact.IsBanned;
            IsVerified = contact.IsVerified;
        }

        #endregion

    }
}
