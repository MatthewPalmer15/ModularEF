using FluentValidation;
using Modular.Core.Identity;
using System.Text.RegularExpressions;

namespace Modular.Core.Services.Validation
{
    public class IdentityValidator : AbstractValidator<ApplicationUser>
    {

        private readonly IModularIdentityManager _identityManager;

        public IdentityValidator(IModularIdentityManager identityManager)
        {
            _identityManager = identityManager;

            RuleFor(e => e.UserName)
                .NotEmpty().WithMessage("Name is required")
                .Must(IsUserNameUnique).WithMessage("Username is already used. Please enter a unique username.)");

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("Email is required")
                .Must(IsEmailUnique).WithMessage("Email is already used. Please enter another email.)");

            RuleFor(e => e.PasswordHash)
                .NotEmpty().WithMessage("Password is required");

            RuleFor(e => e.PhoneNumber)
                .MaximumLength(20).WithMessage("Phone Number must not exceed 50 characters.")
                .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("Phone Number not valid");

            RuleFor(e => e.ContactId)
                .NotEmpty().WithMessage("Contact is required");

        }

        private bool IsUserNameUnique(string? userName)
        {
            if (userName == null) return false;

            ApplicationUser? applicationUser = _identityManager.UserManager.FindByNameAsync(userName).Result;
            return applicationUser == null;
        }

        private bool IsEmailUnique(string? email)
        {
            if (email == null) return false;

            ApplicationUser? applicationUser = _identityManager.UserManager.FindByEmailAsync(email).Result;
            return applicationUser != null;
        }


    }
}
