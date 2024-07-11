//using Application.Repositories;
//using AutoMapper;
//using Core.Hashing;
//using Domain.Entities;
//using MediatR;

//namespace Application.Features.Auth.Commands.Register
//{
//    public class RegisterCommand : IRequest<RegisterResponse>
//    {
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public string Email { get; set; }
//        public string Password { get; set; }

//        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
//        {
//            private readonly IUserRepository _userRepository;
//            private readonly IMapper _mapper;

//            public RegisterCommandHandler(IUserRepository userRepository, IMapper mapper)
//            {
//                _userRepository = userRepository;
//                _mapper = mapper;
//            }

//            public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
//            {
//                User mappedUser = _mapper.Map<User>(request);

//                byte[] passwordHash, passwordSalt;

//                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
//                mappedUser.PasswordSalt = passwordSalt;
//                mappedUser.PasswordHash = passwordHash;

//                await _userRepository.AddAsync(mappedUser);

//                RegisterResponse registerResponse = _mapper.Map<RegisterResponse>(mappedUser);
//                return registerResponse;
//            }
//        }
//    }
//}
