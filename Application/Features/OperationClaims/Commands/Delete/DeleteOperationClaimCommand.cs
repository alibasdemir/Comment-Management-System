using Application.Features.OperationClaims.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.Delete
{
    public class DeleteOperationClaimCommand : IRequest<DeleteOperationClaimResponse>
    {
        public int Id { get; set; }

        public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeleteOperationClaimResponse>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<DeleteOperationClaimResponse> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.OperationClaimIdShouldExistWhenSelected(request.Id);

                OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);

                await _operationClaimRepository.DeleteAsync(mappedOperationClaim);

                DeleteOperationClaimResponse deleteOperationClaimResponse = _mapper.Map<DeleteOperationClaimResponse>(mappedOperationClaim);
                return deleteOperationClaimResponse;
            }
        }
    }
}
