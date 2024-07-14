using Application.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Comments.Queries.GetListDynamic
{
    public class GetListDynamicCommentQuery : IRequest<GetListResponse<GetListDynamicCommentResponse>>
    {
        public PageRequest PageRequest { get; set; }
        public DynamicQuery DynamicQuery { get; set; }

        public class GetListDynamicCommentQueryHandler : IRequestHandler<GetListDynamicCommentQuery, GetListResponse<GetListDynamicCommentResponse>>
        {
            private readonly ICommentRepository _commentRepository;
            private readonly IMapper _mapper;

            public GetListDynamicCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
            {
                _commentRepository = commentRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListDynamicCommentResponse>> Handle(GetListDynamicCommentQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Comment> comments = await _commentRepository.GetListByDynamicAsync(
                    request.DynamicQuery,
                    include: i => i.Include(i => i.User).Include(i => i.Assignment),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                 );

                GetListResponse<GetListDynamicCommentResponse> getListDynamicCommentResponse = _mapper.Map<GetListResponse<GetListDynamicCommentResponse>>(comments);
                return getListDynamicCommentResponse;
            }
        }
    }
}
