using Microsoft.Extensions.DependencyInjection;
using Modular.Core.Profiles;
namespace Modular.Core.DependencyInjection
{
    public static partial class ModularServiceCollectionExtension
    {

        public static IServiceCollection AddModularViewModels(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ConfigurationProfile));
            services.AddAutoMapper(typeof(ContactProfile));
            services.AddAutoMapper(typeof(CompanyProfile));
            services.AddAutoMapper(typeof(CountryProfile));

            return services;

        }
    }
}
