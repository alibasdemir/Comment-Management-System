using Application.Features.Comments.Commands.Create;
using Application.Features.Comments.Commands.Delete;
using Application.Features.Comments.Commands.Update;
using AutoMapper;
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
        }
    }
}
