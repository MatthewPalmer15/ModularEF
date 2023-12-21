using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Modular.Core.Entities;
using Modular.Core.Identity;

namespace Modular.Core.DependencyInjection
{
    public static partial class ModularServiceCollectionExtension
    {

        public static IServiceCollection AddModularReports(this IServiceCollection services)
        {

            return services;

        }
    }
}
