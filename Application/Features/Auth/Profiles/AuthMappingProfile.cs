using Application.Features.Auth.Commands.Login;
using AutoMapper;
using Core.Security.Entities;

namespace Application.Features.Auth.Profiles
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            CreateMap<User, LoginCommand>().ReverseMap();
        }
    }
}
