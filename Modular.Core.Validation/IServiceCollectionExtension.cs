using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Modular.Core.Entities;
using Modular.Core.Identity;
using Modular.Core.Validation;
namespace Modular.Core.DependencyInjection
{
    public static partial class ModularServiceCollectionExtension
    {

        public static IServiceCollection AddModularValidation(this IServiceCollection services)
        {
            //  Configure Services.
            services.AddScoped<IValidator<Configuration>, ConfigurationValidator>();
            services.AddScoped<IValidator<Contact>, ContactValidator>();
            services.AddScoped<IValidator<ApplicationUser>, IdentityValidator>();
            services.AddScoped<IValidator<Country>, CountryValidator>();

            return services;

        }
    }
}
