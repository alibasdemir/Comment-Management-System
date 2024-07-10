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

            public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
            {
                _commentRepository = commentRepository;
                _mapper = mapper;
            }

            public async Task<CreateCommentResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
            {
                Comment mappedComment = _mapper.Map<Comment>(request);

                await _commentRepository.AddAsync(mappedComment);

                CreateCommentResponse createCommentResponse = _mapper.Map<CreateCommentResponse>(mappedComment);
                return createCommentResponse;
            }
        }
    }
}
