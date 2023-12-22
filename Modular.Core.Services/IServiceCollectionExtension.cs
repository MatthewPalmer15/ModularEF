using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modular.Core.Entities.Concrete;
using Modular.Core.Identity;
using Modular.Core.Services.EmailSender.Abstract;
using Modular.Core.Services.EmailSender.Concrete;
using Modular.Core.Services.Repositories.Abstract;
using Modular.Core.Services.Repositories.Concrete;
using Modular.Core.Services.Validation;

namespace Modular.Core.DependencyInjection
{
    public static partial class ModularServiceCollectionExtension
    {

        public static IServiceCollection AddModularServices(this IServiceCollection services, IConfigurationManager configurationManager)
        {
            //  Configure Services.
            services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();


            services.AddScoped<IValidator<Configuration>, ConfigurationValidator>();
            services.AddScoped<IValidator<Contact>, ContactValidator>();
            services.AddScoped<IValidator<Company>, CompanyValidator>();
            services.AddScoped<IValidator<Country>, CountryValidator>();
            services.AddScoped<IValidator<ApplicationUser>, IdentityValidator>();
            services.AddScoped<IValidator<Invoice>, InvoiceValidator>();

            var emailSettings = configurationManager.GetSection("EmailSettings");

            services.AddFluentEmail(emailSettings["DefaultFromEmail"])
                .AddSmtpSender(
                    emailSettings["Host"],              // Host
                    int.Parse(emailSettings["Port"]),   // Port
                    emailSettings["Username"],          // Username
                    emailSettings["Password"]           // Password

                );

            services.AddScoped<IEmailSenderService, EmailSenderService>();

            return services;

        }
    }
}
