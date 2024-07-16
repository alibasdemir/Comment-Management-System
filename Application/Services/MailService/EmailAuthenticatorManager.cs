using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.EmailCodeGenerator;
using Core.Security.Entities;
using Infrastructure.Mail;
using MimeKit;

namespace Application.Services.MailService
{
    internal class EmailAuthenticatorManager : IEmailAuthenticatorService
    {
        private readonly IEmailCodeGeneratorHelper _emailCodeGeneratorHelper;
        private readonly IEmailVerificationRepository _emailVerificationRepository;
        private readonly IMailService _mailService;

        public EmailAuthenticatorManager(IEmailCodeGeneratorHelper emailCodeGeneratorHelper, IEmailVerificationRepository emailVerificationRepository, IMailService mailService)
        {
            _emailCodeGeneratorHelper = emailCodeGeneratorHelper;
            _emailVerificationRepository = emailVerificationRepository;
            _mailService = mailService;
        }

        public async Task SendAuthenticatorCode(User user)
        {
            await SendAuthenticatorCodeWithEmail(user);
        }

        public async Task VerifyAuthenticatorCode(User user, string authenticatorCode)
        {
            await VerifyAuthenticatorCodeWithEmail(user, authenticatorCode);
        }

        private async Task SendAuthenticatorCodeWithEmail(User user)
        {
            EmailVerification? emailVerification = await _emailVerificationRepository.GetAsync(i => i.UserId == user.Id);
            if (emailVerification == null)
            {
                throw new NotFoundException("Email Authenticator not found.");
            }

            string authenticatorCode = await _emailCodeGeneratorHelper.CreateEmailGenerateCode();
            emailVerification.VerificationCode = authenticatorCode;
            await _emailVerificationRepository.UpdateAsync(emailVerification);

            var toEmailList = new List<MailboxAddress>
            {
                new($"{user.FirstName} {user.LastName}", user.Email)
            };

             _mailService.SendMail(
                new Mail
                {
                    ToList = toEmailList,
                    Subject = $"Your Authenticator Code: - {authenticatorCode}",
                    TextBody = $"TEXT Enter your authenticator code: {authenticatorCode}",
                    HtmlBody = $"HTML Enter your authenticator code: {authenticatorCode}"
                }
            );
        }

        private async Task VerifyAuthenticatorCodeWithEmail(User user, string authenticatorCode)
        {
            EmailVerification? emailVerification = await _emailVerificationRepository.GetAsync(i => i.UserId == user.Id);
            if (emailVerification == null)
            {
                throw new NotFoundException("Email Authenticator not found.");
            }
            if (emailVerification.VerificationCode != authenticatorCode) 
            {
                throw new BusinessException("Verification code is invalid.");
            }
            emailVerification.VerificationCode = null;
            await _emailVerificationRepository.UpdateAsync(emailVerification);
        }
    }
}
