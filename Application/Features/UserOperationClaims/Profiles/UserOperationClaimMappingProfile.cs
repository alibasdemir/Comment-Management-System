using Application.Features.UserOperationClaims.Commands.Create;
using Application.Features.UserOperationClaims.Commands.Delete;
using Application.Features.UserOperationClaims.Commands.Update;
using Application.Features.UserOperationClaims.Queries.GetById;
using Application.Features.UserOperationClaims.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Profiles
{
    public class UserOperationClaimMappingProfile : Profile
    {
        public UserOperationClaimMappingProfile()
        {
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, CreateUserOperationClaimResponse>().ReverseMap();
            CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, UpdateUserOperationClaimResponse>().ReverseMap();
            CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, DeleteUserOperationClaimResponse>().ReverseMap();
            CreateMap<UserOperationClaim, GetByIdUserOperationClaimQuery>().ReverseMap();
            CreateMap<UserOperationClaim, GetByIdUserOperationClaimResponse>().ReverseMap();
            CreateMap<UserOperationClaim, GetListUserOperationClaimQuery>().ReverseMap();
            CreateMap<UserOperationClaim, GetListUserOperationClaimResponse>().ReverseMap();
            CreateMap<IPaginate<UserOperationClaim>, GetListResponse<GetListUserOperationClaimResponse>>().ReverseMap();
        }
    }
}
