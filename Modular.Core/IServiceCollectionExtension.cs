﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modular.Core.Identity;

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

        public static IServiceCollection AddModularCore(this IServiceCollection services, IdentityType identityType, Action<DbContextOptionsBuilder> dbContextOptionsBuilder)
        {
            //  Add regular DB Context.
            services.AddDbContext<ModularDbContext>(dbContextOptionsBuilder);

            //  Add Identity DB Context if needed
            switch (identityType)
            {
                case IdentityType.IndividualAccounts:
                    services.AddDbContext<ModularIdentityDbContext>(dbContextOptionsBuilder);

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

                    services.AddScoped<IModularIdentityManager, ModularIdentityManager>();
                    break;

                default:
                    break;
            }


            return services;

        }

    }
}
