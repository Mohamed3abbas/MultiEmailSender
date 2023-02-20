using EmailSender.MVC.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using static EmailSender.MVC.Services.Mailing_Services.MailingServices;

namespace EmailSender.MVC.Services.Mailing_Services
{
    public class MailingServices : IMailingServices
    {

        private readonly MailSettings _mailSettings;

        public MailingServices(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(IList<string> mailTos, string subject, string body)
        {
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_mailSettings.Email),
                Subject = subject
            };

            foreach (var mailTo in mailTos)
            {
                email.To.Add(MailboxAddress.Parse(mailTo));
            }

            var builder = new BodyBuilder();

           

            builder.HtmlBody = body;
            email.Body = builder.ToMessageBody();
            email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Email));

            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Email, _mailSettings.Password);
            await smtp.SendAsync(email);

            smtp.Disconnect(true);
        }
    }
}

