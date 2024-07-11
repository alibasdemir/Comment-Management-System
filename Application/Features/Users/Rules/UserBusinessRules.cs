using Application.Features.Auth.Constants;
using Application.Features.Users.Constants;
using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules : BaseBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserIdShouldExistWhenSelected(int id)
        {
            User? result = await _userRepository.GetAsync(predicate: b => b.Id == id, enableTracking: false);
            if (result == null)
                throw new BusinessException(UserMessages.UserDontExists);
        }

        public Task UserShouldBeExist(User? user)
        {
            if (user is null)
                throw new BusinessException(UserMessages.UserDontExists);
            return Task.CompletedTask;
        }

        public Task UserPasswordShouldBeMatch(User user, string password)
        {
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new BusinessException(UserMessages.PasswordDontMatch);
            return Task.CompletedTask;
        }

        public async Task UserEmailShouldBeNotExists(string email)
        {
            User? user = await _userRepository.GetAsync(predicate: u => u.Email == email, enableTracking: false);
            if (user != null)
                throw new BusinessException(AuthMessages.UserMailAlreadyExists);
        }
    }
}
