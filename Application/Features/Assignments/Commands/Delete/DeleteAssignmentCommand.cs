using Application.Features.Assignments.Constants;
using Application.Features.Assignments.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Assignments.Commands.Delete
{
    public class DeleteAssignmentCommand : IRequest<DeleteAssignmentResponse>, ILoggableRequest, ICacheRemoverRequest, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => ["Admin", AssignmentOperationClaims.Admin, AssignmentOperationClaims.Delete];

        public bool BypassCache { get; }
        public string? CacheKey { get; }
        public string CacheGroupKey => "GetAssignments";

        public class DeleteAssignmentCommandHandler : IRequestHandler<DeleteAssignmentCommand, DeleteAssignmentResponse>
        {
            private readonly IAssignmentRepository _assignmentRepository;
            private readonly IMapper _mapper;
            private readonly AssignmentBusinessRules _assignmentBusinessRules;

            public DeleteAssignmentCommandHandler(IAssignmentRepository assignmentRepository, IMapper mapper, AssignmentBusinessRules assignmentBusinessRules)
            {
                _assignmentRepository = assignmentRepository;
                _mapper = mapper;
                _assignmentBusinessRules = assignmentBusinessRules;
            }

            public async Task<DeleteAssignmentResponse> Handle(DeleteAssignmentCommand request, CancellationToken cancellationToken)
            {
                await _assignmentBusinessRules.AssignmentShouldExistWhenSelected(request.Id);

                Assignment mappedAssignment = _mapper.Map<Assignment>(request);

                await _assignmentRepository.DeleteAsync(mappedAssignment);

                DeleteAssignmentResponse deleteAssignmentResponse = _mapper.Map<DeleteAssignmentResponse>(mappedAssignment);
                return deleteAssignmentResponse;
            }
        }
    }
}
