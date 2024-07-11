using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;

namespace Application.Features.Assignments.Commands.Create
{
    public class CreateAssignmentCommand : IRequest<CreateAssignmentResponse>, ISecuredRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string[] Roles => [];

        public class CreateAssignmentCommandHandler : IRequestHandler<CreateAssignmentCommand, CreateAssignmentResponse>
        {
            private readonly IAssignmentRepository _assignmentRepository;
            private readonly IMapper _mapper;

            public CreateAssignmentCommandHandler(IAssignmentRepository assignmentRepository, IMapper mapper)
            {
                _assignmentRepository = assignmentRepository;
                _mapper = mapper;
            }

            public async Task<CreateAssignmentResponse> Handle(CreateAssignmentCommand request, CancellationToken cancellationToken)
            {
                Assignment mappedAssignment = _mapper.Map<Assignment>(request);
                
                await _assignmentRepository.AddAsync(mappedAssignment);

                CreateAssignmentResponse createdAssignmentResponse = _mapper.Map<CreateAssignmentResponse>(mappedAssignment);
                return createdAssignmentResponse;

                
                // FOR MANUEL :

                //Assignment mappedAssignment = new Assignment
                //{
                //    Title = request.Title,
                //    Description = request.Description
                //};

                //await _assignmentRepository.AddAsync(mappedAssignment);

                //CreateAssignmentResponse createdAssignmentResponse = new CreateAssignmentResponse
                //{
                //    Id = mappedAssignment.Id,
                //    Title = mappedAssignment.Title,
                //    Description = mappedAssignment.Description,
                //    CreatedDate = mappedAssignment.CreatedDate 
                //};

                //return createdAssignmentResponse;
            }
        }
    }
}
