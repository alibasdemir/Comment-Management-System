using Core.Security.Entities;

namespace Application.Services.MailService
{
    public interface IEmailAuthenticatorService
    {
        public Task SendAuthenticatorCode(User user);
        public Task VerifyAuthenticatorCode(User user, string authenticatorCode);
    }
}
