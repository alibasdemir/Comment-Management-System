using Application.Features.Comments.Commands.Create;
using Application.Features.Comments.Commands.Delete;
using Application.Features.Comments.Commands.Update;
using Application.Features.Comments.Queries.GetById;
using Application.Features.Comments.Queries.GetList;
using Application.Features.Comments.Queries.GetListDynamic;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Comments.Profiles
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comment, CreateCommentCommand>().ReverseMap();
            CreateMap<Comment, CreateCommentResponse>().ReverseMap();
            CreateMap<Comment, UpdateCommentCommand>().ReverseMap();
            CreateMap<Comment, UpdateCommentResponse>().ReverseMap();
            CreateMap<Comment, DeleteCommentCommand>().ReverseMap();
            CreateMap<Comment, DeleteCommentResponse>().ReverseMap();
            CreateMap<Comment, GetByIdCommentQuery>().ReverseMap();
            CreateMap<Comment, GetByIdCommentResponse>().ReverseMap();
            CreateMap<Comment, GetListCommentQuery>().ReverseMap();
            CreateMap<Comment, GetListCommentResponse>()
                .ForMember(destinationMember: i => i.UserEmail, memberOptions: opt => opt.MapFrom(i => i.User.Email))
                .ForMember(destinationMember: i => i.UserFirstName, memberOptions: opt => opt.MapFrom(i => i.User.FirstName))
                .ForMember(destinationMember: i => i.UserLastName, memberOptions: opt => opt.MapFrom(i => i.User.LastName))
                .ForMember(destinationMember: i => i.AssignmentTitle, memberOptions: opt => opt.MapFrom(i => i.Assignment.Title))
                .ReverseMap();
            CreateMap<IPaginate<Comment>, GetListResponse<GetListCommentResponse>>().ReverseMap();
            CreateMap<Comment, GetListDynamicCommentQuery>().ReverseMap();
            CreateMap<Comment, GetListDynamicCommentResponse>()
                .ForMember(destinationMember: i => i.UserEmail, memberOptions: opt => opt.MapFrom(i => i.User.Email))
                .ForMember(destinationMember: i => i.UserFirstName, memberOptions: opt => opt.MapFrom(i => i.User.FirstName))
                .ForMember(destinationMember: i => i.UserLastName, memberOptions: opt => opt.MapFrom(i => i.User.LastName))
                .ForMember(destinationMember: i => i.AssignmentTitle, memberOptions: opt => opt.MapFrom(i => i.Assignment.Title))
                .ReverseMap();
            CreateMap<IPaginate<Comment>, GetListResponse<GetListDynamicCommentResponse>>().ReverseMap();
        }
    }
}
