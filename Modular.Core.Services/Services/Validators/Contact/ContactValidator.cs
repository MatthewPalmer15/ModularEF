using FluentValidation;
using Modular.Core.Entities;
using System.Text.RegularExpressions;

namespace Modular.Core.Services.Validation
{
    public class ContactValidator : AbstractValidator<Contact>
    {

        public ContactValidator()
        {

            RuleFor(e => e.Forename)
                .NotEmpty().WithMessage("Forename is required");

            RuleFor(e => e.Surname)
                .NotEmpty().WithMessage("Surname is required");

            RuleFor(e => e.DateOfBirth)
                .LessThan(DateTime.Today.AddDays(1)).WithMessage("Date Of Birth is invalid");

            RuleFor(e => e.AddressLine1)
                .Length(0, 128).WithMessage("Address Line 1 is too long.");

            RuleFor(e => e.AddressLine2)
                .Length(0, 128).WithMessage("Address Line 2 is too long.");

            RuleFor(e => e.AddressLine3)
                .Length(0, 128).WithMessage("Address Line 3 is too long.");

            RuleFor(e => e.AddressCity)
                .Length(0, 128).WithMessage("Address City is too long.");

            RuleFor(e => e.AddressCounty)
                .Length(0, 128).WithMessage("Address County is too long.");

            RuleFor(e => e.AddressPostcode)
                .Length(0, 128).WithMessage("Address Postcode is too long.");

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage("Email is invalid")
                .MaximumLength(255).WithMessage("Email is invalid");

            //      Phone Number Validation
            //      https://stackoverflow.com/questions/12908536/how-to-validate-the-phone-no
            RuleFor(e => e.Phone)
                .MaximumLength(20).WithMessage("Phone Number must not exceed 50 characters.")
                .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("Phone Number not valid");

            RuleFor(e => e.Mobile)
                .MaximumLength(20).WithMessage("Phone Number must not exceed 50 characters.")
                .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("Phone Number not valid");

        }
    }
}
