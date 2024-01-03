using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Modular.Core.Services;
using Modular.Core.Services.Repositories.Abstract;
using Modular.Core.Services.Repositories.Concrete;

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

            services.AddScoped<IScheduledTaskRepository, ScheduledTaskRepository>();
            services.AddScoped<IScheduledTaskService, ScheduledTaskService>();

            return services;
        }

    }
}
