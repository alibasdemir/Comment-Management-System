using Application.Features.Assignments.Commands.Create;
using Application.Features.Assignments.Commands.Delete;
using Application.Features.Assignments.Commands.Update;
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
            CreateMap<Assignment, UpdateAssignmentCommand>().ReverseMap();
            CreateMap<Assignment, UpdateAssignmentResponse>().ReverseMap();
            CreateMap<Assignment, DeleteAssignmentCommand>().ReverseMap();
            CreateMap<Assignment, DeleteAssignmentResponse>().ReverseMap();
        }
    }
}
