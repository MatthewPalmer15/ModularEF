#nullable disable

using Modular.Core.Models.Location;
using Modular.Core.Models.Misc;

namespace Modular.Core.Models.Entity
{
    public class Contact : BaseEntity
    {

        #region "  Enums  "

        public enum GenderType
        {
            Unknown = 0,
            Male = 1,
            Female = 2,
            Other = 3,
            PreferNotToSay = 4

        }

        public enum TitleType
        {
            Unknown = 0,
            Mr = 1,
            Mrs = 2,
            Ms = 3,
            Miss = 4,
            Dr = 5
        }

        #endregion

        #region "  Properties  "

        public TitleType? Title { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public GenderType? Gender { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string AddressCity { get; set; }

        public string AddressCounty { get; set; }

        public Guid? AddressCountryId { get; set; }

        public virtual Country AddressCountry { get; set; }

        public string AddressPostcode { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public Guid? OccupationId { get; set; }

        public virtual Occupation Occupation { get; set; }

        public Guid? DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public Guid? OrganisationId { get; set; }

        public virtual Organisation Organisation { get; set; }

        public bool IsVerified { get; set; }

        public bool IsBanned { get; set; }

        #endregion

    }
}
