using Application.Features.Auth.Commands.ChangePassword;
using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.Register;
using AutoMapper;
using Core.Security.Entities;

namespace Application.Features.Auth.Profiles
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            CreateMap<User, LoginCommand>().ReverseMap();
            CreateMap<User, RegisterCommand>().ReverseMap();
            CreateMap<User, RegisterResponse>().ReverseMap();
            CreateMap<User, ChangePasswordCommand>().ReverseMap();
            CreateMap<User, ChangePasswordResponse>().ReverseMap();
        }
    }
}
