using FluentValidation;
using Modular.Core.Entities;

namespace Modular.Core.Services.Validation
{
    public class CompanyValidator : AbstractValidator<Company>
    {

        public CompanyValidator() 
        {

            RuleFor(e => e.Name)
                .NotNull().WithMessage("Name is required")
                .NotEmpty().WithMessage("Name is required");

            RuleFor(e => e.Email)
                .NotNull().WithMessage("Email is required")
                .NotEmpty().WithMessage("Email is required");

        }

    }
}
