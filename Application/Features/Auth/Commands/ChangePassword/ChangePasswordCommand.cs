using Application.Features.Auth.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using MediatR;

namespace Application.Features.Auth.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<ChangePasswordResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }

        public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ChangePasswordResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly AuthBusinessRules _authBusinessRules;

            public ChangePasswordCommandHandler(IUserRepository userRepository, IMapper mapper, AuthBusinessRules authBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<ChangePasswordResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
            {
                User? existingUser = await _userRepository.GetAsync(i => i.Email == request.Email);
                await _authBusinessRules.UserShouldBeExist(existingUser);

                await _authBusinessRules.UserPasswordShouldBeMatch(existingUser.Id, request.Password);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.NewPassword, out passwordHash, out passwordSalt);
                existingUser.PasswordSalt = passwordSalt;
                existingUser.PasswordHash = passwordHash;

                await _userRepository.UpdateAsync(existingUser);

                ChangePasswordResponse changePasswordResponse = _mapper.Map<ChangePasswordResponse>(existingUser);
                return changePasswordResponse;
            }
        }
    }
}
