using Application.Features.UserOperationClaims.Rules;
using Application.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.Create
{
    public class CreateUserOperationClaimCommand : IRequest<CreateUserOperationClaimResponse>
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreateUserOperationClaimResponse>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

            public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            }

            public async Task<CreateUserOperationClaimResponse> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _userOperationClaimBusinessRules.UserIdShouldExist(request.UserId);

                await _userOperationClaimBusinessRules.OperationClaimExist(request.OperationClaimId);

                await _userOperationClaimBusinessRules.UserShouldNotAlreadyHaveOperationClaim(request.UserId, request.OperationClaimId);

                UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);

                await _userOperationClaimRepository.AddAsync(mappedUserOperationClaim);

                CreateUserOperationClaimResponse createUserOperationClaimResponse = _mapper.Map<CreateUserOperationClaimResponse>(mappedUserOperationClaim);
                return createUserOperationClaimResponse;
            }
        }
    }
}
