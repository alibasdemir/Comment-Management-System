using Application.Features.UserOperationClaims.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.Update
{
    public class UpdateUserOperationClaimCommand : IRequest<UpdateUserOperationClaimResponse>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, UpdateUserOperationClaimResponse>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

            public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            }

            public async Task<UpdateUserOperationClaimResponse> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _userOperationClaimBusinessRules.UserOperationClaimIdShouldExistWhenSelected(request.Id);
                
                await _userOperationClaimBusinessRules.UserIdShouldExist(request.UserId);

                await _userOperationClaimBusinessRules.OperationClaimExist(request.OperationClaimId);

                await _userOperationClaimBusinessRules.UserShouldNotAlreadyHaveOperationClaim(request.UserId, request.OperationClaimId);

                UserOperationClaim? existingUserOperationClaim = await _userOperationClaimRepository.GetAsync(i => i.Id == request.Id);
                _mapper.Map(request, existingUserOperationClaim);

                await _userOperationClaimRepository.UpdateAsync(existingUserOperationClaim);

                UpdateUserOperationClaimResponse updateUserOperationClaimResponse = _mapper.Map<UpdateUserOperationClaimResponse>(existingUserOperationClaim);
                return updateUserOperationClaimResponse;
            }
        }
    }
}
