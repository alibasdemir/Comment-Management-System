using Application.Features.AuthWithVerifyCode.Rules;
using Application.Repositories;
using Application.Services.MailService;
using Application.Services.UserService;
using AutoMapper;
using Core.Application.Pipelines.Logging;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.AuthWithVerifyCode.Commands.VerifyEmail
{
    public class VerifyEmailCommand : IRequest<VerifyEmailResponse>, ILoggableRequest
    {
        public string Email { get; set; }
        public string VerifyCode { get; set; }

        public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand, VerifyEmailResponse>
        {
            private readonly IEmailVerificationRepository _emailVerificationRepository;
            private readonly IEmailAuthenticatorService _emailAuthenticatorService;
            private readonly IUserService _userService;
            private readonly AuthWithVerifyCodeBusinessRules _authWithVerifyCodeBusinessRules;
            private readonly IMapper _mapper;

            public VerifyEmailCommandHandler(IEmailAuthenticatorService emailAuthenticatorService, IUserService userService, IEmailVerificationRepository emailVerificationRepository, IMapper mapper, AuthWithVerifyCodeBusinessRules authWithVerifyCodeBusinessRules)
            {
                _emailAuthenticatorService = emailAuthenticatorService;
                _userService = userService;
                _emailVerificationRepository = emailVerificationRepository;
                _mapper = mapper;
                _authWithVerifyCodeBusinessRules = authWithVerifyCodeBusinessRules;
            }

            public async Task<VerifyEmailResponse> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
            {
                User user = await _userService.GetByEmail(request.Email);
                await _authWithVerifyCodeBusinessRules.UserEmailShouldBeExist(request.Email);
                await _authWithVerifyCodeBusinessRules.UserEmailVerified(user.Id);

                await _emailAuthenticatorService.VerifyAuthenticatorCode(user, request.VerifyCode);

                var emailVerification = await _emailVerificationRepository.GetAsync(e => e.UserId == user.Id);
                emailVerification.IsVerified = true;
                await _emailVerificationRepository.UpdateAsync(emailVerification);

                return _mapper.Map<VerifyEmailResponse>(emailVerification);

            }
        }
    }
}
