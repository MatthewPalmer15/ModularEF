using FluentValidation;
using Modular.Core.Models.Misc;

namespace Modular.Core.Validaton.Misc
{
    public class DepartmentValidator : AbstractValidator<Department>
    {

        public DepartmentValidator()
        {

            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(128).WithMessage("Name must not exceed 128 characters.");


            RuleFor(e => e.Description)
                .MaximumLength(512).WithMessage("Description must not exceed 512 characters.");

        }

    }
}
