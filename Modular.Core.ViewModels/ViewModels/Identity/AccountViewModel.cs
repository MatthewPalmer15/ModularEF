#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Modular.Core.ViewModels.Identity
{
    public class AccountViewModel
    {

        [Display(Name = "Forename")]
        public string Forename { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateOnly DateOfBirth { get; set; }

        [Display(Name = "Address Line")]
        public string AddressLine1 { get; set; }

        [Display(Name = "")]
        public string AddressLine2 { get; set; }

        [Display(Name = "")]
        public string AddressLine3 { get; set; }

        [Display(Name = "City")]
        public string AddressCity { get; set; }

        [Display(Name = "County")]
        public string AddressCounty { get; set; }

        [Display(Name = "Country")]
        public string AddressCountry { get; set; }

        [Display(Name = "Postcode")]
        public string AddressPostcode { get; set; }

        // [Display(Name = "Facebook")]
        // public string FacebookLink { get; set; }
        // 
        // [Display(Name = "Instagram")]
        // public string InstagramLink { get; set; }
        // 
        // [Display(Name = "Twitter")]
        // public string TwitterLink { get; set; }
        // 
        // [Display(Name = "LinkedIn")]
        // public string LinkedInLink { get; set; }
        // 
        // [Display(Name = "Website")]
        // public string WebsiteLink { get; set; }

        public bool IsVerified { get; set; }

    }
}
