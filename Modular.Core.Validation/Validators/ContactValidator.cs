using FluentValidation;
using Modular.Core.Models.Entity;

namespace Modular.Core.Validation.Entity
{
    public class ContactValidator : AbstractValidator<Contact>
    {

        public ContactValidator()
        {

            RuleFor(e => e.Forename)
                .NotNull().WithMessage("Forename is required")
                .NotEmpty().WithMessage("Forename is required");

            RuleFor(e => e.Forename)
                .NotEmpty().WithMessage("Forename is required");

            RuleFor(e => e.DateOfBirth)
                .LessThan(DateTime.Today.AddDays(1)).WithMessage("Date Of Birth is invalid");


            //      RuleFor(customer => customer.Address.Postcode).NotNull().When(customer => customer.Address != null)
            //      RuleFor(customer => customer.Address).SetValidator(new AddressValidator());
            //      RuleFor(x => x.Postcode).Must(BeAValidPostcode).WithMessage("Please specify a valid postcode");
            // }
            // 
            // private bool BeAValidPostcode(string postcode)
            // {
            //     // custom postcode validating logic goes here
            // }
        }
    }
}
