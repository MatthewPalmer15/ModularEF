#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Modular.Core.ViewModels.Identity
{
    public class AccountRegisterModel
    {

        public string Forename { get; set; }

        public string Surname { get; set; }

        [Required]
        public string Username { get; set; }


        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
