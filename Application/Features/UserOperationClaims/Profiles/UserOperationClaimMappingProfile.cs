using Application.Features.UserOperationClaims.Commands.Create;
using AutoMapper;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Profiles
{
    public class UserOperationClaimMappingProfile : Profile
    {
        public UserOperationClaimMappingProfile()
        {
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, CreateUserOperationClaimResponse>().ReverseMap();
        }
    }
}
