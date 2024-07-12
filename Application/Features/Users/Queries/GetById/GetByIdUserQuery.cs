using Application.Features.Users.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Users.Queries.GetById
{
    public class GetByIdUserQuery : IRequest<GetByIdUserResponse>
    {
        public int Id { get; set; }

        public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, GetByIdUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<GetByIdUserResponse> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserIdShouldExistWhenSelected(request.Id);

                User? user = await _userRepository.GetAsync(i => i.Id == request.Id);

                GetByIdUserResponse getByIdUserResponse = _mapper.Map<GetByIdUserResponse>(user);
                return getByIdUserResponse;
            }
        }
    }
}
