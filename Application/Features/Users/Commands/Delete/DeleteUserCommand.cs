using Application.Features.Users.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest<DeleteUserResponse>
    {
        public int Id { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IMapper _mapper;

            public DeleteUserCommandHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules, IMapper mapper)
            {
                _userRepository = userRepository;
                _userBusinessRules = userBusinessRules;
                _mapper = mapper;
            }

            public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                User mappedUser = _mapper.Map<User>(request);

                await _userBusinessRules.UserIdShouldExistWhenSelected(request.Id);

                await _userRepository.DeleteAsync(mappedUser);

                DeleteUserResponse deleteUserResponse = _mapper.Map<DeleteUserResponse>(mappedUser);
                return deleteUserResponse;
            }
        }
    }
}
