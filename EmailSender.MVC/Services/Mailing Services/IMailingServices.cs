namespace EmailSender.MVC.Services.Mailing_Services
{
    public interface IMailingServices
    {
        Task SendEmailAsync(IList<string> mailTos, string subject, string body);
    }
}
