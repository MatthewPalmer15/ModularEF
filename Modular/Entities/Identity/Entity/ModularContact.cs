using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core
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

        public TitleType Title { get; set; } = TitleType.Unknown;

        public string Forename { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;

        public GenderType Gender { get; set; } = GenderType.Unknown;

        public string AddressLine1 { get; set; } = string.Empty;

        public string AddressLine2 { get; set; } = string.Empty;

        public string AddressLine3 { get; set; } = string.Empty;

        public string AddressCity { get; set; } = string.Empty;

        public string AddressCounty { get; set; } = string.Empty;

        public Guid AddressCountryID { get; set; } = Guid.Empty;

        public string AddressPostcode { get; set; } = string.Empty;


        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public string Fax { get; set; } = string.Empty;

        public string FacebookLink { get; set; } = string.Empty;

        public string InstagramLink { get; set; } = string.Empty;

        public string TwitterLink { get; set; } = string.Empty;

        public string LinkedInLink { get; set; } = string.Empty;

        public string WebsiteLink { get; set; } = string.Empty;

        public Guid OccupationID { get; set; } = Guid.Empty;

        public Guid DepartmentID { get; set; } = Guid.Empty;

        public Guid OrganisationID { get; set; } = Guid.Empty;

        public bool IsVerified { get; set; } = false;

        public bool IsBanned { get; set; } = false;

        #endregion

    }
}
