using Application.Features.Assignments.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Assignments.Queries.GetById
{
    public class GetByIdAssignmentQuery : IRequest<GetByIdAssignmentResponse>
    {
        public int Id { get; set; }

        public class GetByIdAssignmentQueryHandler : IRequestHandler<GetByIdAssignmentQuery, GetByIdAssignmentResponse>
        {
            private readonly IAssignmentRepository _assignmentRepository;
            private readonly IMapper _mapper;
            private readonly AssignmentBusinessRules _assignmentBusinessRules;
            public GetByIdAssignmentQueryHandler(IAssignmentRepository assignmentRepository, IMapper mapper, AssignmentBusinessRules assignmentBusinessRules)
            {
                _assignmentRepository = assignmentRepository;
                _mapper = mapper;
                _assignmentBusinessRules = assignmentBusinessRules;
            }

            public async Task<GetByIdAssignmentResponse> Handle(GetByIdAssignmentQuery request, CancellationToken cancellationToken)
            {
                await _assignmentBusinessRules.AssignmentShouldExistWhenSelected(request.Id);

                Assignment? assignment = await _assignmentRepository.GetAsync(i => i.Id == request.Id);

                GetByIdAssignmentResponse getByIdAssignmentResponse = _mapper.Map<GetByIdAssignmentResponse>(assignment);
                return getByIdAssignmentResponse;
            }
        }
    }
}
