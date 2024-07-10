using Application.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Queries.GetList
{
    public class GetListCommentQuery : IRequest<GetListResponse<GetListCommentResponse>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListCommentQueryHandler : IRequestHandler<GetListCommentQuery, GetListResponse<GetListCommentResponse>>
        {
            private readonly ICommentRepository _commentRepository;
            private readonly IMapper _mapper;

            public GetListCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
            {
                _commentRepository = commentRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListCommentResponse>> Handle(GetListCommentQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Comment> comments = await _commentRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                GetListResponse<GetListCommentResponse> getListCommentResponse = _mapper.Map<GetListResponse<GetListCommentResponse>>(comments);
                return getListCommentResponse;
            }
        }
    }
}
