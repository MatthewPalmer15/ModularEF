using FluentValidation;
using Modular.Core.Entities.Concrete;

namespace Modular.Core.Services.Validation
{
    public class CountryValidator : AbstractValidator<Country>
    {

        public CountryValidator()
        {

            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(128).WithMessage("Name must not exceed 128 characters.");


            RuleFor(e => e.Description)
                .MaximumLength(512).WithMessage("Description must not exceed 512 characters.");

            RuleFor(e => e.Code)
                .MaximumLength(4).WithMessage("Code must not exceed 2 characters.");

        }

    }
}
