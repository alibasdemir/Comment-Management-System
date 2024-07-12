using Application.Features.Comments.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Commands.Update
{
    public class UpdateCommentCommand : IRequest<UpdateCommentResponse>
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }

        public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, UpdateCommentResponse>
        {
            private readonly ICommentRepository _commentRepository;
            private readonly IMapper _mapper;
            private readonly CommentBusinessRules _commentBusinessRules;

            public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper, CommentBusinessRules commentBusinessRules)
            {
                _commentRepository = commentRepository;
                _mapper = mapper;
                _commentBusinessRules = commentBusinessRules;
            }

            public async Task<UpdateCommentResponse> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
            {
                await _commentBusinessRules.CommentIdShouldExistWhenSelected(request.Id);

                await _commentBusinessRules.UserIdShouldExist(request.UserId);

                await _commentBusinessRules.AssignmentIdShouldExist(request.AssignmentId);

                Comment? existingComment = await _commentRepository.GetAsync(i => i.Id == request.Id);
                _mapper.Map(request, existingComment);

                await _commentRepository.UpdateAsync(existingComment);

                UpdateCommentResponse updateCommentResponse = _mapper.Map<UpdateCommentResponse>(existingComment);
                return updateCommentResponse;
            }
        }
    }
}
