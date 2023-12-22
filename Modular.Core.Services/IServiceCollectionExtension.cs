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

        public static IServiceCollection AddModularServices(this IServiceCollection services)
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

            return services;

        }

        public static IServiceCollection AddModularEmailSender(this IServiceCollection services, string defaultFromEmail, string host, int port, string? username = null, string? password = null)
        {
            if (username == null || password == null)
            {
                services.AddFluentEmail(defaultFromEmail)
                        .AddSmtpSender(host, port, username, password);
            }
            else
            {
                services.AddFluentEmail(defaultFromEmail)
                        .AddSmtpSender(host, port);
            }

            services.AddScoped<IEmailSenderService, EmailSenderService>();

            return services;
        }

        public static IServiceCollection AddModularEmailSender(this IServiceCollection services, IConfigurationManager configurationManager)
        {
            var emailSettings = configurationManager.GetSection("EmailSettings");

            string? username = emailSettings["Username"];
            string? password = emailSettings["Password"];

            if (username == null || password == null)
            {
                services.AddFluentEmail(emailSettings["DefaultFromEmail"])
                        .AddSmtpSender(emailSettings["DefaultFromEmail"], int.Parse(emailSettings["Port"] ?? ""), username, password);
            }
            else
            {
                services.AddFluentEmail(emailSettings["DefaultFromEmail"])
                        .AddSmtpSender(emailSettings["DefaultFromEmail"], int.Parse(emailSettings["Port"] ?? ""));
            }

            services.AddScoped<IEmailSenderService, EmailSenderService>();

            return services;
        }

    }
}
