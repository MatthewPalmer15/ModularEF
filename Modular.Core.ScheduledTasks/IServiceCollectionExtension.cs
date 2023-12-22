using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace Modular.Core.DependencyInjection
{
    public static partial class ModularServiceCollectionExtension
    {

        public static IServiceCollection AddModularScheduledTasks(this IServiceCollection services, string connectionString, CompatibilityLevel compatibilityLevel = CompatibilityLevel.Version_180)
        {

            services.AddHangfire(configuration => configuration
                            .SetDataCompatibilityLevel(compatibilityLevel)
                            .UseSimpleAssemblyNameTypeSerializer()
                            .UseRecommendedSerializerSettings()
                            .UseSqlServerStorage(connectionString)
            );

            services.AddHangfireServer();

            return services;
        }
    }
}
