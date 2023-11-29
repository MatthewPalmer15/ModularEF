using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Modular.Core.ViewModels.Identity
{

    public class AccountUsernameLoginModel
    {

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }


        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
    public class AccountEmailLoginModel
    {

        [Required]
        [Display(Name = "Username")]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}