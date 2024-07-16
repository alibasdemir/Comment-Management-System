using Application.Features.AuthWithVerifyCode.Commands.LoginWithCode;
using Application.Features.AuthWithVerifyCode.Commands.RegisterWithCode;
using Application.Features.AuthWithVerifyCode.Commands.VerifyEmail;
using AutoMapper;
using Core.Security.Entities;

namespace Application.Features.AuthWithVerifyCode.Profiles
{
    public class AuthWithVerifyCodeMappingProfile : Profile
    {
        public AuthWithVerifyCodeMappingProfile()
        {
            CreateMap<EmailVerification, VerifyEmailResponse>()
                .ForMember(dest => dest.IsVerified, opt => opt.MapFrom(src => src.IsVerified))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Email has been successfully verified."));
            CreateMap<User, RegisterWithCodeCommand>().ReverseMap();
            CreateMap<User, RegisterWithCodeResponse>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "User registered successfully. Please check your email to verify your account."));
            CreateMap<User, LoginWithCodeCommand>().ReverseMap();
        }
    }
}
