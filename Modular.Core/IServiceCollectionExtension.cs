using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modular.Core.Identity;
using Modular.Core.Interfaces;

namespace Modular.Core.DependencyInjection
{

    public enum AuthenticationType
    {
        None = 0,
        IndividualAccounts = 1,
    }

    public static partial class ModularServiceCollectionExtension
    {

        /// <summary>
        /// Add Core Component of Modular to Services.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="authenticationType">What authentication takes place.</param>
        /// <param name="isCodeFirstDatabase">If database and tables should be created using migrations.</param>
        /// <param name="dbContextOptionsBuilder">Database Context options.</param>
        /// <returns></returns>
        public static IServiceCollection AddModularCore(this IServiceCollection services, AuthenticationType authenticationType, bool isCodeFirstDatabase, Action<DbContextOptionsBuilder> dbContextOptionsBuilder)
        {
            services.AddHttpContextAccessor();

            //  Add Identity DB Context if needed
            switch (authenticationType)
            {
                case AuthenticationType.IndividualAccounts:
                    services.AddDbContext<ModularIdentityDbContext>(dbContextOptionsBuilder);
                    services.AddScoped<IDbContext, ModularIdentityDbContext>();

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
                    //  Add regular DB Context.
                    services.AddDbContext<ModularDbContext>(dbContextOptionsBuilder);
                    services.AddScoped<IDbContext, ModularDbContext>();

                    break;
            }

            //  Create database and migrate if db is codefirst.
            if (isCodeFirstDatabase) RunDatabaseMigrations(services, authenticationType);

            return services;
        }

        internal static void RunDatabaseMigrations(IServiceCollection services, AuthenticationType authenticationType)
        {
            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                switch (authenticationType)
                {
                    case AuthenticationType.IndividualAccounts:
                        var dbIdentityContext = scope.ServiceProvider.GetRequiredService<ModularIdentityDbContext>();
                        dbIdentityContext.Database.EnsureCreated();

                        // Apply pending migrations
                        if (dbIdentityContext.Database.GetPendingMigrations().Any()) dbIdentityContext.Database.Migrate();
                        break;

                    default:
                        var dbContext = scope.ServiceProvider.GetRequiredService<ModularDbContext>();
                        dbContext.Database.EnsureCreated();

                        // Apply pending migrations
                        if (dbContext.Database.GetPendingMigrations().Any()) dbContext.Database.Migrate();
                        break;
                }

            }
        }

    }
}
