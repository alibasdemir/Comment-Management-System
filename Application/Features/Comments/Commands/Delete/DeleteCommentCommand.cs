using Application.Features.Comments.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Commands.Delete
{
    public class DeleteCommentCommand : IRequest<DeleteCommentResponse>
    {
        public int Id { get; set; }

        public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, DeleteCommentResponse>
        {
            private readonly ICommentRepository _commentRepository;
            private readonly IMapper _mapper;
            private readonly CommentBusinessRules _commentBusinessRules;

            public DeleteCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper, CommentBusinessRules commentBusinessRules)
            {
                _commentRepository = commentRepository;
                _mapper = mapper;
                _commentBusinessRules = commentBusinessRules;
            }

            public async Task<DeleteCommentResponse> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
            {
                await _commentBusinessRules.CommentIdShouldExistWhenSelected(request.Id);

                Comment mappedComment = _mapper.Map<Comment>(request);

                await _commentRepository.DeleteAsync(mappedComment);

                DeleteCommentResponse deleteCommentResponse = _mapper.Map<DeleteCommentResponse>(mappedComment);
                return deleteCommentResponse;
            }
        }
    }
}
