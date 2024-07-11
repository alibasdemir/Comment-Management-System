using Application.Features.Auth.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, AccessToken>
        {
            private readonly IUserRepository _userRepository;
            private readonly AuthBusinessRules _authBusinessRules;
            private ITokenHelper _tokenHelper;
            private IUserOperationClaimRepository _userOperationClaimRepository;
            public LoginCommandHandler(IUserRepository userRepository, AuthBusinessRules authBusinessRules, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userRepository = userRepository;
                _authBusinessRules = authBusinessRules;
                _tokenHelper = tokenHelper;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<AccessToken> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(i => i.Email == request.Email);
                await _authBusinessRules.UserShouldBeExist(user);
                await _authBusinessRules.UserPasswordShouldBeMatch(user.Id, request.Password);

                // refactor..
                IPaginate<UserOperationClaim> userOperationClaimsPaginate = await _userOperationClaimRepository.GetListAsync(i => i.UserId == user.Id, include: i => i.Include(i => i.OperationClaim));
                List<UserOperationClaim> userOperationClaims = userOperationClaimsPaginate.Items.ToList();

                return _tokenHelper.CreateToken(user, userOperationClaims.Select(i => i.OperationClaim).ToList());
            }
        }
    }
}
