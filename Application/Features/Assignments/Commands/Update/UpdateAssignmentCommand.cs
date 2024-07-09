using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Assignments.Commands.Update
{
    public class UpdateAssignmentCommand : IRequest<UpdateAssignmentResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public class UpdateAssignmentCommandHandler : IRequestHandler<UpdateAssignmentCommand, UpdateAssignmentResponse>
        {
            private readonly IAssignmentRepository _assignmentRepository;
            private readonly IMapper _mapper;

            public UpdateAssignmentCommandHandler(IAssignmentRepository assignmentRepository, IMapper mapper)
            {
                _assignmentRepository = assignmentRepository;
                _mapper = mapper;
            }

            public async Task<UpdateAssignmentResponse> Handle(UpdateAssignmentCommand request, CancellationToken cancellationToken)
            {
                Assignment mappedAssignment = _mapper.Map<Assignment>(request);

                await _assignmentRepository.UpdateAsync(mappedAssignment);

                UpdateAssignmentResponse updateAssignmentResponse = _mapper.Map<UpdateAssignmentResponse>(mappedAssignment);
                return updateAssignmentResponse;
            }
        }
    }
}
