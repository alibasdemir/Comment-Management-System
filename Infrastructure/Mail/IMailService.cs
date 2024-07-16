namespace Infrastructure.Mail
{
    public interface IMailService
    {
        void SendMail(Mail mail);
        Task SendEmailAsync(Mail mail);
    }
}
