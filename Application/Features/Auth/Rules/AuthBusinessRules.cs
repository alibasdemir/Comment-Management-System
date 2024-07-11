using Application.Features.Auth.Constants;
using Application.Repositories;
using Core.Application.Rules;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace Application.Features.Auth.Rules
{
    public class AuthBusinessRules : BaseBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task UserShouldBeExist(User? user)
        {
            if (user == null)
            {
                throw new Exception(AuthMessages.UserDontExists);
            }
            return Task.CompletedTask;
        }

        public async Task UserEmailShouldBeNotExists(string email)
        {
            User? user = await _userRepository.GetAsync(predicate: u => u.Email == email, enableTracking: false);
            if (user != null)
                throw new Exception(AuthMessages.UserMailAlreadyExists);
        }

        public async Task UserPasswordShouldBeMatch(int id, string password)
        {
            User? user = await _userRepository.GetAsync(predicate: u => u.Id == id, enableTracking: false);
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new Exception(AuthMessages.PasswordDontMatch);
        }
    }
}
