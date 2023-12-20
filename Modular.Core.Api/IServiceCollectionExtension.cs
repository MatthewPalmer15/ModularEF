using Microsoft.Extensions.DependencyInjection;
using Modular.Core.Api;


namespace Modular.Core.DependencyInjection
{
    public static partial class ModularServiceCollectionExtension
    {

        public static IServiceCollection AddModularApi(this IServiceCollection services, string? baseUrl)
        {
            //  Configure Services.
            services.AddScoped<IApiService, ApiService>(provider => new ApiService(baseUrl));
            return services;

        }
    }
}
