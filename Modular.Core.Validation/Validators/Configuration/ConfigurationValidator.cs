using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Modular.Core.Models.Config;
using Modular.Core.Models.Entity;

namespace Modular.Core.Validation.Entity
{
    public class ConfigurationValidator : AbstractValidator<Configuration>
    {

        private readonly ModularDbContext _context;

        public ConfigurationValidator(ModularDbContext context)
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
                    .Where(x => x.Key.Trim().ToUpper() == key.Trim().ToUpper())
                    .SingleOrDefault();

            return configuration == null;
        }
    }
}
