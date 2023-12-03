#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Modular.Core.ViewModels.Identity
{
    public class AccountUsernameLoginModel
    {

        [Required]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }

    public class AccountEmailLoginModel
    {

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}