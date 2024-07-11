using Application.Features.Users.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using MediatR;

namespace Application.Features.Users.Commands.Create
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(i=> i.Email == request.Email);
                await _userBusinessRules.UserEmailShouldBeNotExists(request.Email);

                User mappedUser = _mapper.Map<User>(request);

                byte[] passwordHash, passwordSalt;

                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                mappedUser.PasswordSalt = passwordSalt;
                mappedUser.PasswordHash = passwordHash;

                await _userRepository.AddAsync(mappedUser);

                CreateUserResponse createUserResponse = _mapper.Map<CreateUserResponse>(mappedUser);
                return createUserResponse;
            }
        }
    }
}
