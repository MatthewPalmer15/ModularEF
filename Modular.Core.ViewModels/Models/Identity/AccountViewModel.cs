using Modular.Core.Identity;
using Modular.Core.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace matthewpalmer.dev.Models.Account
{
    public class AccountViewModel
    {

        public AccountViewModel(ApplicationUser applicationUser)
        {

            this.Forename = applicationUser.Contact.Forename;
            this.Surname = applicationUser.Contact.Surname;

            this.Username = applicationUser.UserName ?? "";
            this.Email = applicationUser.Email ?? "";
            this.Phone = applicationUser.PhoneNumber ?? "";

            this.DateOfBirth = DateOnly.FromDateTime(applicationUser.Contact.DateOfBirth);

            this.AddressLine1 = applicationUser.Contact.AddressLine1;
            this.AddressLine2 = applicationUser.Contact.AddressLine2;
            this.AddressLine3 = applicationUser.Contact.AddressLine3;
            this.AddressCity = applicationUser.Contact.AddressCity;
            this.AddressCounty = applicationUser.Contact.AddressCounty;
            this.AddressCountry = applicationUser.Contact.AddressCountry?.Name ?? "Unknown";
            this.AddressPostcode = applicationUser.Contact.AddressPostcode;

            //this.FacebookLink = applicationUser.Contact.FacebookLink;
            //this.InstagramLink = applicationUser.Contact.InstagramLink;
            //this.TwitterLink = applicationUser.Contact.TwitterLink;
            //this.LinkedInLink = applicationUser.Contact.LinkedInLink;
            //this.WebsiteLink = applicationUser.Contact.WebsiteLink;
            
            this.OrganisationName = applicationUser.Contact.Organisation?.Name ?? "None";
            this.IsVerified = applicationUser.Contact.IsVerified;

        }

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

        [Display(Name = "Facebook")]
        public string FacebookLink { get; set; }

        [Display(Name = "Instagram")]
        public string InstagramLink { get; set; }

        [Display(Name = "Twitter")]
        public string TwitterLink { get; set; }

        [Display(Name = "LinkedIn")]
        public string LinkedInLink { get; set; }

        [Display(Name = "Website")]
        public string WebsiteLink { get; set; }

        [Display(Name = "Organisation")]
        public string OrganisationName { get; set; }

        public bool IsVerified { get; set; }


    }
}
