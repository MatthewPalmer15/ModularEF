using FluentValidation;
using Modular.Core.Identity;
using System.Text.RegularExpressions;

namespace Modular.Core.Validation
{
    public class IdentityValidator : AbstractValidator<ApplicationUser>
    {

        private readonly ModularIdentityDbContext _context;

        public IdentityValidator(ModularIdentityDbContext context)
        {
            _context = context;

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
            ApplicationUser? applicationUser = _context.ApplicationUsers
                    .Where(x => x.UserName != null && x.UserName.Trim().ToUpper() == userName.Trim().ToUpper())
                    .SingleOrDefault();

            return applicationUser == null;
        }

        private bool IsEmailUnique(string? email)
        {
            ApplicationUser? applicationUser = _context.ApplicationUsers
                    .Where(x => x.Email != null && x.Email.Trim().ToUpper() == email.Trim().ToUpper())
                    .SingleOrDefault();

            return applicationUser == null;
        }


    }
}
