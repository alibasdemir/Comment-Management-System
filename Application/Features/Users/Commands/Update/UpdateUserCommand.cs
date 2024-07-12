using Application.Features.Users.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using MediatR;

namespace Application.Features.Users.Commands.Update
{
    public class UpdateUserCommand : IRequest<UpdateUserResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserIdShouldExistWhenSelected(request.Id);
                await _userBusinessRules.UserEmailShouldBeNotExists(request.Email);

                User? existingUser = await _userRepository.GetAsync(i => i.Id == request.Id);
                _mapper.Map(request, existingUser);

                byte[] passwordHash, passwordSalt;

                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                existingUser.PasswordSalt = passwordSalt;
                existingUser.PasswordHash = passwordHash;

                await _userRepository.UpdateAsync(existingUser);

                UpdateUserResponse updateUserResponse = _mapper.Map<UpdateUserResponse>(existingUser);
                return updateUserResponse;
            }
        }
    }
}
