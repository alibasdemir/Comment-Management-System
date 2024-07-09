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

            public DeleteAssignmentCommandHandler(IAssignmentRepository assignmentRepository, IMapper mapper)
            {
                _assignmentRepository = assignmentRepository;
                _mapper = mapper;
            }

            public async Task<DeleteAssignmentResponse> Handle(DeleteAssignmentCommand request, CancellationToken cancellationToken)
            {
                Assignment mappedAssignment = _mapper.Map<Assignment>(request);

                await _assignmentRepository.DeleteAsync(mappedAssignment);

                DeleteAssignmentResponse deleteAssignmentResponse = _mapper.Map<DeleteAssignmentResponse>(mappedAssignment);
                return deleteAssignmentResponse;
            }
        }
    }
}
