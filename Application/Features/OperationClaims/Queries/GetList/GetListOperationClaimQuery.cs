using Application.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Queries.GetList
{
    public class GetListOperationClaimQuery : IRequest<GetListResponse<GetListOperationClaimResponse>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, GetListResponse<GetListOperationClaimResponse>>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListOperationClaimResponse>> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<OperationClaim> operationClaims = await _operationClaimRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                GetListResponse<GetListOperationClaimResponse> getListOperationClaimResponse = _mapper.Map<GetListResponse<GetListOperationClaimResponse>>(operationClaims);
                return getListOperationClaimResponse;
            }
        }
    }
}
