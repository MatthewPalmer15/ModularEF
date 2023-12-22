using FluentEmail.Core;
using Modular.Core.Services.EmailSender.Abstract;

namespace Modular.Core.Services.EmailSender.Concrete
{
    public class EmailSenderService : IEmailSenderService
    {

        private readonly IFluentEmail _fluentEmail;

        public EmailSenderService(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail ?? throw new ArgumentNullException(nameof(fluentEmail));
        }

        public bool SendEmail(Email email)
        {
            var response = email.Send();
            return response.Successful;
        }

        public async Task<bool> SendEmailAsync(Email email)
        {
            var response = await email.SendAsync();
            return response.Successful;
        }


    }
}
