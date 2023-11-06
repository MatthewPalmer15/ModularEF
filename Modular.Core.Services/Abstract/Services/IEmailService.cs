using Modular.Core.Identity;
using System.Net.Mail;


namespace Modular.Core.Services.Abstract.Services
{
    public interface IEmailService
    {

        public string SmtpClientAddress { get; }

        public string SmtpClientPort { get; }

        public bool SendEmail(MailMessage mailMessage);

        public Task<bool> SendEmailAsync(MailMessage mailMessage);

        public (bool isSuccessful, int? twoFactorCode) SendTwoFactorAuthenticationEmail(ApplicationUser applicationUser);

        public Task<(bool isSuccessful, int? twoFactorCode)> SendTwoFactorAuthenticationEmailAsync(ApplicationUser applicationUser);

    }
}
