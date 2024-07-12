using Application.Features.Comments.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Queries.GetById
{
    public class GetByIdCommentQuery : IRequest<GetByIdCommentResponse>
    {
        public int Id { get; set; }

        public class GetByIdCommentQueryHandler : IRequestHandler<GetByIdCommentQuery, GetByIdCommentResponse>
        {
            private readonly ICommentRepository _commentRepository;
            private readonly IMapper _mapper;
            private readonly CommentBusinessRules _commentBusinessRules;

            public GetByIdCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper, CommentBusinessRules commentBusinessRules)
            {
                _commentRepository = commentRepository;
                _mapper = mapper;
                _commentBusinessRules = commentBusinessRules;
            }

            public async Task<GetByIdCommentResponse> Handle(GetByIdCommentQuery request, CancellationToken cancellationToken)
            {
                await _commentBusinessRules.CommentIdShouldExistWhenSelected(request.Id);

                Comment? comment = await _commentRepository.GetAsync(i => i.Id ==  request.Id);

                GetByIdCommentResponse getByIdCommentResponse = _mapper.Map<GetByIdCommentResponse>(comment);
                return getByIdCommentResponse;
            }
        }
    }
}
