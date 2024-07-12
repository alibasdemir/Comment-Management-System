using Application.Features.UserOperationClaims.Constants;
using Application.Repositories;
using Application.Services.OperationClaimService;
using Application.Services.UserService;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules : BaseBusinessRules
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IUserService _userService;
        private readonly IOperationClaimService _operationClaimService;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository, IUserService userService, IOperationClaimService operationClaimService)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userService = userService;
            _operationClaimService = operationClaimService;
        }

        public async Task UserOperationClaimIdShouldExistWhenSelected(int id)
        {
            UserOperationClaim? result = await _userOperationClaimRepository.GetAsync(predicate: i => i.Id == id, enableTracking: false);
            if (result == null)
            {
                throw new BusinessException(UserOperationClaimsMessages.UserOperationClaimNotExists);
            }
        }

        public async Task UserIdShouldExist(int id)
        {
            User user = await _userService.GetById(id);
            if (user == null)
            {
                throw new BusinessException(UserOperationClaimsMessages.UserIdShouldExist);
            }
        }

        public async Task OperationClaimExist(int id)
        {
            OperationClaim operationClaim = await _operationClaimService.GetById(id);
            if (operationClaim == null)
            {
                throw new BusinessException(UserOperationClaimsMessages.OperationClaimShouldExist);
            }
        }

        public async Task UserShouldNotAlreadyHaveOperationClaim(int userId, int operationClaimId)
        {
            var userOperationClaim = await _userOperationClaimRepository.GetAsync(
                predicate: i => i.UserId == userId && i.OperationClaimId == operationClaimId,
                enableTracking: false);

            if (userOperationClaim != null)
            {
                throw new BusinessException(UserOperationClaimsMessages.UserAlreadyHasThisRole);
            }
        }
    }
}
