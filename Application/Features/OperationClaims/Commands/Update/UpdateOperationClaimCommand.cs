using Application.Features.OperationClaims.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.Update
{
    public class UpdateOperationClaimCommand : IRequest<UpdateOperationClaimResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdateOperationClaimResponse>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<UpdateOperationClaimResponse> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.OperationClaimIdShouldExistWhenSelected(request.Id);

                OperationClaim? existingOperationClaim = await _operationClaimRepository.GetAsync(i => i.Id == request.Id);
                _mapper.Map(request, existingOperationClaim);

                await _operationClaimRepository.UpdateAsync(existingOperationClaim);

                UpdateOperationClaimResponse updateOperationClaimResponse = _mapper.Map<UpdateOperationClaimResponse>(existingOperationClaim);
                return updateOperationClaimResponse;
            }
        }
    }
}
