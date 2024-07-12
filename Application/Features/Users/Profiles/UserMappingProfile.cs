using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.Users.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, CreateUserResponse>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserResponse>().ReverseMap();
            CreateMap<User, DeleteUserCommand>().ReverseMap();
            CreateMap<User, DeleteUserResponse>().ReverseMap();
            CreateMap<User, GetByIdUserQuery>().ReverseMap();
            CreateMap<User, GetByIdUserResponse>().ReverseMap();
            CreateMap<User, GetListUserQuery>().ReverseMap();
            CreateMap<User, GetListUserResponse>().ReverseMap();
            CreateMap<Paginate<User>, GetListResponse<GetListUserResponse>>().ReverseMap();
        }
    }
}
