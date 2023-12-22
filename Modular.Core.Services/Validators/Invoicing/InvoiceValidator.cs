using FluentValidation;
using Modular.Core.Entities.Concrete;

namespace Modular.Core.Services.Validation
{
    public class InvoiceValidator : AbstractValidator<Invoice>
    {

        public InvoiceValidator()
        {

            RuleFor(x => x.InvoiceNumber)
                .NotEmpty().WithMessage("Invoice Number should not be empty");

        }

    }
}
