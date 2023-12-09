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

namespace Modular.Core.DependencyInjection
{

    public enum IdentityType
    {
        None = 0,
        IndividualAccounts = 1,
    }

    public enum DatabaseType
    {
        None = 0,
        SQLServer = 1,
    }

    public static partial class ModularServiceCollectionExtension
    {

        public static IServiceCollection AddModularCore(this IServiceCollection services, IdentityType identityType, DatabaseType databaseType, string? connectionString, string? migrationAssembly)
        {
            //  Add regular DB Context.
            services.AddDbContext<ModularDbContext>(options =>
            {
                switch (databaseType)
                {
                    case DatabaseType.SQLServer:
                        options.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationAssembly));
                        break;

                    default:
                        break;
                }
            });
            
            //  Add Identity DB Context if needed
            switch (identityType)
            {
                case IdentityType.IndividualAccounts:
                    services.AddDbContext<ModularIdentityDbContext>(options =>
                    {
                        switch (databaseType)
                        {
                            case DatabaseType.SQLServer:
                                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationAssembly));
                                break;

                            default:
                                break;
                        }
                    });
                    break;

                default:
                    break;
            }


            return services;

        }
    }
}
