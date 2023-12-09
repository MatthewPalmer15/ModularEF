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
using Microsoft.Extensions.DependencyInjection.Extensions;

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

                    services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
                    {
                        options.Password.RequireUppercase = true;
                        options.Password.RequireLowercase = true;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireDigit = true;
                        options.Password.RequiredLength = 8;
                        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                        options.Lockout.MaxFailedAccessAttempts = 5;
                        options.Lockout.AllowedForNewUsers = true;

                        // User settings.
                        options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                        options.User.RequireUniqueEmail = true;

                    }).AddEntityFrameworkStores<ModularIdentityDbContext>()
                      .AddRoles<ApplicationRole>()
                      .AddDefaultTokenProviders();
                    break;

                default:
                    break;
            }


            return services;

        }

    }
}
