using Application.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.Create
{
    public class CreateOperationClaimCommand : IRequest<CreateOperationClaimResponse>
    {
        public string Name { get; set; }

        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreateOperationClaimResponse>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<CreateOperationClaimResponse> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);

                await _operationClaimRepository.AddAsync(mappedOperationClaim);

                CreateOperationClaimResponse createOperationClaimResponse = _mapper.Map<CreateOperationClaimResponse>(mappedOperationClaim);
                return createOperationClaimResponse;
            }
        }
    }
}
