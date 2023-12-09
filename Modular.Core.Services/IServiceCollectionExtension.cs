using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modular.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Identity;
using Microsoft.AspNetCore.Identity;
using Modular.Core.Services.Repositories.Abstract;
using Modular.Core.Services.Repositories.Concrete;
using Modular.Core.Services.Managers.Abstract;
using Modular.Core.Services.Managers.Concrete;

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
