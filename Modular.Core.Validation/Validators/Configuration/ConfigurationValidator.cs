using FluentValidation;
using Modular.Core.Entities;
using Modular.Core.Interfaces;

namespace Modular.Core.Validation
{
    public class ConfigurationValidator : AbstractValidator<Configuration>
    {

        private readonly IDbContext _context;

        public ConfigurationValidator(IDbContext context)
        {
            _context = context;

            RuleFor(e => e.Key)
                .NotNull().WithMessage("Key is required")
                .NotEmpty().WithMessage("Key is required")
                .Must(IsKeyUnique).WithMessage("Key is already used. Please enter a unique key.)");


            RuleFor(e => e.Value)
                .NotNull().WithMessage("Value is required")
                .NotEmpty().WithMessage("Value is required");
        }

        private bool IsKeyUnique(string key)
        {
            Configuration? configuration = _context.Configurations
                    .Where(x => x.Key.Trim().Equals(key.Trim(), StringComparison.CurrentCultureIgnoreCase))
                    .SingleOrDefault();

            return configuration == null;
        }
    }
}
