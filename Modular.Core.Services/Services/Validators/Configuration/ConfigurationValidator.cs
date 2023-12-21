using FluentValidation;
using Modular.Core.Entities.Concrete;
using Modular.Core.Interfaces;

namespace Modular.Core.Services.Validation
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
                .Must((configuration, key) => IsKeyUnique(key, configuration.Id)).WithMessage("Key is already used. Please enter a unique key.");


            RuleFor(e => e.Value)
                .NotNull().WithMessage("Value is required")
                .NotEmpty().WithMessage("Value is required");
        }

        private bool IsKeyUnique(string key, Guid configurationId)
        {
            Configuration? configuration = _context.Configurations
                    .SingleOrDefault(x => x.Key.Trim() == key.Trim() && x.Id != configurationId);

            return configuration == null;
        }
    }
}
