using Application.Features.Assignments.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Assignments.Commands.Delete
{
    public class DeleteAssignmentCommand : IRequest<DeleteAssignmentResponse>
    {
        public int Id { get; set; }

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
