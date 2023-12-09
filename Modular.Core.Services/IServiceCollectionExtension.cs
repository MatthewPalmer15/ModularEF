using Microsoft.Extensions.DependencyInjection;
using Modular.Core.Services.Managers.Abstract;
using Modular.Core.Services.Managers.Concrete;
using Modular.Core.Services.Repositories.Abstract;
using Modular.Core.Services.Repositories.Concrete;

namespace Modular.Core.DependencyInjection
{
    public static partial class ModularServiceCollectionExtension
    {

        public static IServiceCollection AddModularServices(this IServiceCollection services)
        {
            //  Configure Services.
            services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();

            services.AddScoped<IModularIdentityManager, ModularIdentityManager>();

            return services;

        }
    }
}
