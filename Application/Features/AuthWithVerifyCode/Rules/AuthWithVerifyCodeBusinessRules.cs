using Application.Features.AuthWithVerifyCode.Constants;
using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace Application.Features.AuthWithVerifyCode.Rules
{
    public class AuthWithVerifyCodeBusinessRules : BaseBusinessRules
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailVerificationRepository _emailVerificationRepository;

        public AuthWithVerifyCodeBusinessRules(IUserRepository userRepository, IEmailVerificationRepository emailVerificationRepository)
        {
            _userRepository = userRepository;
            _emailVerificationRepository = emailVerificationRepository;
        }
        public async Task UserEmailShouldBeExist(string email)
        {
            User? user = await _userRepository.GetAsync(i => i.Email == email);
            if (user == null)
            {
                throw new BusinessException(AuthWithVerifyCodeMessages.UserEmailNotFound);
            }
        }

        public async Task UserEmailShouldBeNotExist(string email)
        {
            User? user = await _userRepository.GetAsync(predicate: i => i.Email == email, enableTracking: false);
            if (user != null)
            {
                throw new BusinessException(AuthWithVerifyCodeMessages.UserMailAlreadyExist);
            }
        }

        public async Task UserEmailVerified(int userId)
        {
            EmailVerification? emailVerification = await _emailVerificationRepository.GetAsync(i => i.UserId == userId);
            if (emailVerification != null && emailVerification.IsVerified)
            {
                throw new BusinessException(AuthWithVerifyCodeMessages.UserEmailVerified);
            }
        }

        public async Task UserEmailNotVerified(int userId)
        {
            EmailVerification? emailVerification = await _emailVerificationRepository.GetAsync(i => i.UserId == userId);
            if (emailVerification != null && !emailVerification.IsVerified)
            {
                throw new BusinessException(AuthWithVerifyCodeMessages.UserEmailNotVerified);
            }
        }

        public Task UserShouldBeExist(User? user)
        {
            if (user == null)
            {
                throw new Exception(AuthWithVerifyCodeMessages.UserDontExists);
            }
            return Task.CompletedTask;
        }

        public async Task UserPasswordShouldBeMatch(int id, string password)
        {
            User? user = await _userRepository.GetAsync(predicate: u => u.Id == id, enableTracking: false);
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new Exception(AuthWithVerifyCodeMessages.PasswordDontMatch);
        }
    }
}
