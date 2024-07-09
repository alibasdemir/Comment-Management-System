using Application.Features.Assignments.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Assignments.Profiles
{
    public class AssignmentMappingProfile : Profile
    {
        public AssignmentMappingProfile()
        {
            CreateMap<Assignment, CreateAssignmentCommand>().ReverseMap();
            CreateMap<Assignment, CreateAssignmentResponse>().ReverseMap();
        }
    }
}
