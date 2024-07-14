using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Assignments.Queries.GetList
{
    public class GetListAssignmentQuery : IRequest<GetListResponse<GetListAssignmentResponse>>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }

        public string CacheKey => $"GetListAssignment-{PageRequest.Page}, {PageRequest.PageSize}";
        public string CacheGroupKey => "GetAssignments";
        public bool BypassCache { get; set; } // default: false. dont want true cause cache will be bypassed. or can be used -> public bool BypassCache => false;
        public TimeSpan? SlidingExpiration { get; set; } // or public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(30);

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
                    include: i => i.Include(i => i.Comments),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                GetListResponse<GetListAssignmentResponse> getListAssignmentResponse = _mapper.Map<GetListResponse<GetListAssignmentResponse>>(assignments);
                return getListAssignmentResponse;
            }
        }
    }
}
