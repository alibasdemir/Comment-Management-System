using Application.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Assignments.Queries.GetListDynamic
{
    public class GetListDynamicAssignmentQuery : IRequest<GetListResponse<GetListDynamicAssignmentResponse>>
    {
        public PageRequest PageRequest { get; set; }
        public DynamicQuery DynamicQuery { get; set; }

        public class GetListDynamicAssignmentQueryHandler : IRequestHandler<GetListDynamicAssignmentQuery, GetListResponse<GetListDynamicAssignmentResponse>>
        {
            private readonly IAssignmentRepository _assignmentRepository;
            private readonly IMapper _mapper;

            public GetListDynamicAssignmentQueryHandler(IAssignmentRepository assignmentRepository, IMapper mapper)
            {
                _assignmentRepository = assignmentRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListDynamicAssignmentResponse>> Handle(GetListDynamicAssignmentQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Assignment> assignments = await _assignmentRepository.GetListByDynamicAsync(
                    request.DynamicQuery,
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                GetListResponse<GetListDynamicAssignmentResponse> getListDynamicAssignmentResponse = _mapper.Map<GetListResponse<GetListDynamicAssignmentResponse>>(assignments);
                return getListDynamicAssignmentResponse;
            }
        }
    }
}
