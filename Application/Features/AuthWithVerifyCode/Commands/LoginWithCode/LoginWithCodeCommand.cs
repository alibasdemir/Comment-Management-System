using Application.Features.AuthWithVerifyCode.Rules;
using Application.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AuthWithVerifyCode.Commands.LoginWithCode
{
    public class LoginWithCodeCommand : IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginWithCodeCommandHandler : IRequestHandler<LoginWithCodeCommand, AccessToken>
        {
            private readonly IUserRepository _userRepository;
            private readonly AuthWithVerifyCodeBusinessRules _authWithVerifyCodeBusinessRules;
            private readonly ITokenHelper _tokenHelper;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public LoginWithCodeCommandHandler(IUserRepository userRepository, AuthWithVerifyCodeBusinessRules authWithVerifyCodeBusinessRules, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userRepository = userRepository;
                _authWithVerifyCodeBusinessRules = authWithVerifyCodeBusinessRules;
                _tokenHelper = tokenHelper;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<AccessToken> Handle(LoginWithCodeCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(i => i.Email == request.Email);
                await _authWithVerifyCodeBusinessRules.UserShouldBeExist(user);
                await _authWithVerifyCodeBusinessRules.UserPasswordShouldBeMatch(user.Id, request.Password);
                await _authWithVerifyCodeBusinessRules.UserEmailNotVerified(user.Id);

                IPaginate<UserOperationClaim> userOperationClaimsPaginate = await _userOperationClaimRepository.GetListAsync(i => i.UserId == user.Id, include: i => i.Include(i => i.OperationClaim));
                List<UserOperationClaim> userOperationClaims = userOperationClaimsPaginate.Items.ToList();

                return _tokenHelper.CreateToken(user, userOperationClaims.Select(i => i.OperationClaim).ToList());
            }
        }
    }
}
