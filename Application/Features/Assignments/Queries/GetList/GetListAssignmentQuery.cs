using Application.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Assignments.Queries.GetList
{
    public class GetListAssignmentQuery : IRequest<GetListResponse<GetListAssignmentResponse>>
    {
       public PageRequest PageRequest { get; set; }

        public class GetListAssignmentQueryHandler : IRequestHandler<GetListAssignmentQuery, GetListResponse<GetListAssignmentResponse>>
        {
            private readonly IAssignmentRepository _assignmentRepository;
            private readonly IMapper _mapper;

            public GetListAssignmentQueryHandler(IAssignmentRepository assignmentRepository, IMapper mapper)
            {
                _assignmentRepository = assignmentRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListAssignmentResponse>> Handle(GetListAssignmentQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Assignment> assignments = await _assignmentRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                GetListResponse<GetListAssignmentResponse> getListAssignmentResponse = _mapper.Map<GetListResponse<GetListAssignmentResponse>>(assignments);
                return getListAssignmentResponse;
            }
        }
    }
}
