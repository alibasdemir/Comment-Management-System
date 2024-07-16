using Application.Features.AuthWithVerifyCode.Rules;
using Application.Repositories;
using Application.Services.MailService;
using AutoMapper;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Entities;
using Core.Security.Hashing;
using MediatR;

namespace Application.Features.AuthWithVerifyCode.Commands.RegisterWithCode
{
    public class RegisterWithCodeCommand : IRequest<RegisterWithCodeResponse>, ILoggableRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class RegisterWithCodeCommandHandler : IRequestHandler<RegisterWithCodeCommand, RegisterWithCodeResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly IEmailAuthenticatorService _emailAuthenticatorService;
            private readonly IEmailVerificationRepository _emailVerificationRepository;
            private readonly AuthWithVerifyCodeBusinessRules _authWithVerifyCodeBusinessRules;


            public RegisterWithCodeCommandHandler(IUserRepository userRepository, IMapper mapper, IEmailAuthenticatorService emailAuthenticatorService, IEmailVerificationRepository emailVerificationRepository, AuthWithVerifyCodeBusinessRules authWithVerifyCodeBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _emailAuthenticatorService = emailAuthenticatorService;
                _emailVerificationRepository = emailVerificationRepository;
                _authWithVerifyCodeBusinessRules = authWithVerifyCodeBusinessRules;
            }

            public async Task<RegisterWithCodeResponse> Handle(RegisterWithCodeCommand request, CancellationToken cancellationToken)
            {
                await _authWithVerifyCodeBusinessRules.UserEmailShouldBeNotExist(request.Email);

                byte[] passwordSalt, passwordHash;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                User user = _mapper.Map<User>(request);
                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;

                await _userRepository.AddAsync(user);

                EmailVerification emailVerification = new EmailVerification
                {
                    UserId = user.Id,
                    IsVerified = false
                };
                await _emailVerificationRepository.AddAsync(emailVerification);

                // todo: refactor...
                try
                {
                    await _emailAuthenticatorService.SendAuthenticatorCode(user);
                }
                catch (Exception ex) 
                {
                    // E-posta gönderilemediyse kullanıcı kaydını geri al ---> refactor - refactor - refactor
                    await _userRepository.DeleteAsync(user);
                    throw new BusinessException("Email could not be sent, registration was cancelled.");
                }

                RegisterWithCodeResponse registerWithCodeResponse = _mapper.Map<RegisterWithCodeResponse>(user);
                return registerWithCodeResponse;
            }
        }
    }
}
