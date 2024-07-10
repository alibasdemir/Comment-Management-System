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

            public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
            {
                _commentRepository = commentRepository;
                _mapper = mapper;
            }

            public async Task<UpdateCommentResponse> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
            {
                Comment? existingComment = await _commentRepository.GetAsync(i => i.Id == request.Id);
                _mapper.Map(request, existingComment);

                await _commentRepository.UpdateAsync(existingComment);

                UpdateCommentResponse updateCommentResponse = _mapper.Map<UpdateCommentResponse>(existingComment);
                return updateCommentResponse;
            }
        }
    }
}
