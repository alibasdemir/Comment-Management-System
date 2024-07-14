using Application.Features.Assignments.Commands.Create;
using Application.Features.Assignments.Commands.Delete;
using Application.Features.Assignments.Commands.Update;
using Application.Features.Assignments.Queries.GetById;
using Application.Features.Assignments.Queries.GetList;
using Application.Features.Assignments.Queries.GetListDynamic;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
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
            CreateMap<Assignment, GetByIdAssignmentQuery>().ReverseMap();
            CreateMap<Assignment, GetByIdAssignmentResponse>().ReverseMap();
            CreateMap<Assignment, GetListAssignmentQuery>().ReverseMap();
            CreateMap<Assignment, GetListAssignmentResponse>()
                .ForMember(destinationMember: dest => dest.Comments, memberOptions: opt => opt.MapFrom(src => src.Comments))
                .ReverseMap();
            CreateMap<IPaginate<Assignment>, GetListResponse<GetListAssignmentResponse>>().ReverseMap();
            CreateMap<Assignment, GetListDynamicAssignmentQuery>().ReverseMap();
            CreateMap<Assignment, GetListDynamicAssignmentResponse>().ReverseMap();
            CreateMap<IPaginate<Assignment>, GetListResponse<GetListDynamicAssignmentResponse>>().ReverseMap();
        }
    }
}
