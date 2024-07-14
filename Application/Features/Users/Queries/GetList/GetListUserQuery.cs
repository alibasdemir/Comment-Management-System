using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Users.Queries.GetList
{
    public class GetListUserQuery : IRequest<GetListResponse<GetListUserResponse>>, IIntervalRequest
    {
        public PageRequest PageRequest { get; set; }

        public int Interval { get; set; } = 1;

        public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, GetListResponse<GetListUserResponse>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            public GetListUserQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListUserResponse>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
            {
                IPaginate<User> users = await _userRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                GetListResponse<GetListUserResponse> getListUserResponse = _mapper.Map<GetListResponse<GetListUserResponse>>(users);
                return getListUserResponse;
            }
        }
    }
}
