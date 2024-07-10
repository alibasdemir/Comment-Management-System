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
                // Assignment mappedAssignment = _mapper.Map<Assignment>(request);
                // We dont use this cause;
                // * Preserve the current value of CreatedDate because we dont want it to be updated

                // Use;
                Assignment? existingAssignment = await _assignmentRepository.GetAsync(i => i.Id == request.Id);
                _mapper.Map(request, existingAssignment);

                await _assignmentRepository.UpdateAsync(existingAssignment);

                UpdateAssignmentResponse updateAssignmentResponse = _mapper.Map<UpdateAssignmentResponse>(existingAssignment);
                return updateAssignmentResponse;
            }
        }
    }
}
