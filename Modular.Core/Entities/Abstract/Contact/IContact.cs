using Modular.Core.Entities.Concrete;
using Modular.Core.Interfaces;

namespace Modular.Core.Entities.Abstract
{
    public interface IContact : IBaseEntity<Guid>
    {

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

        public TitleType? Title { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public GenderType? Gender { get; set; }

        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? AddressLine3 { get; set; }

        public string? AddressCity { get; set; }

        public string? AddressCounty { get; set; }

        public Guid? AddressCountryId { get; set; }

        public Country? AddressCountry { get; set; }

        public string? AddressPostcode { get; set; }

        public string Email { get; set; }

        public string? Phone { get; set; }

        public string? Mobile { get; set; }

        public Guid? CompanyId { get; set; }

        public Company? Company { get; set; }

        public bool IsVerified { get; set; }

        public bool IsBanned { get; set; }

    }
}
