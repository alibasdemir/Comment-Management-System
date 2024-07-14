using Application.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Dynamic;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Users.Queries.GetListDynamic
{
    public class GetListDynamicUserQuery : IRequest<GetListResponse<GetListDynamicUserResponse>>
    {
        public PageRequest PageRequest { get; set; }
        public DynamicQuery DynamicQuery { get; set; }

        public class GetListDynamicUserQueryHandler : IRequestHandler<GetListDynamicUserQuery, GetListResponse<GetListDynamicUserResponse>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetListDynamicUserQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListDynamicUserResponse>> Handle(GetListDynamicUserQuery request, CancellationToken cancellationToken)
            {
                IPaginate<User> users = await _userRepository.GetListByDynamicAsync(
                    request.DynamicQuery,
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                GetListResponse<GetListDynamicUserResponse> getListDynamicUserResponse = _mapper.Map<GetListResponse<GetListDynamicUserResponse>>(users);
                return getListDynamicUserResponse;
            }
        }
    }
}
