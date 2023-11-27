﻿using System.ComponentModel.DataAnnotations;


namespace matthewpalmer.dev.Models.Account
{
    public class AccountLoginModel
    {

        [Required]
        public string Username { get; set; }


        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }

    public class LoginViewModel2
    {

        [Required]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}