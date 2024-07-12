using Application.Features.OperationClaims.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Queries.GetById
{
    public class GetByIdOperationClaimQuery : IRequest<GetByIdOperationClaimResponse>
    {
        public int Id { get; set; }

        public class GetByIdOperationClaimQueryHandler : IRequestHandler<GetByIdOperationClaimQuery, GetByIdOperationClaimResponse>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public GetByIdOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }
            public async Task<GetByIdOperationClaimResponse> Handle(GetByIdOperationClaimQuery request, CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.OperationClaimIdShouldExistWhenSelected(request.Id);

                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(i => i.Id == request.Id);

                GetByIdOperationClaimResponse getByIdOperationClaimResponse = _mapper.Map<GetByIdOperationClaimResponse>(operationClaim);
                return getByIdOperationClaimResponse;
            }
        }
    }
}
