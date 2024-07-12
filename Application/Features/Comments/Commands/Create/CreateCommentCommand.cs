using Application.Features.Comments.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Commands.Create
{
    public class CreateCommentCommand : IRequest<CreateCommentResponse>
    {
        public int AssignmentId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }

        public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CreateCommentResponse>
        {
            private readonly ICommentRepository _commentRepository;
            private readonly IMapper _mapper;
            private readonly CommentBusinessRules _commentBusinessRules;

            public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper, CommentBusinessRules commentBusinessRules)
            {
                _commentRepository = commentRepository;
                _mapper = mapper;
                _commentBusinessRules = commentBusinessRules;
            }

            public async Task<CreateCommentResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
            {
                await _commentBusinessRules.UserIdShouldExist(request.UserId);
                await _commentBusinessRules.AssignmentIdShouldExist(request.AssignmentId);

                Comment mappedComment = _mapper.Map<Comment>(request);

                await _commentRepository.AddAsync(mappedComment);

                CreateCommentResponse createCommentResponse = _mapper.Map<CreateCommentResponse>(mappedComment);
                return createCommentResponse;
            }
        }
    }
}
