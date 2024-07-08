using Application.Repositories;
using Core.Persistence;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class CommentRepository : EfRepositoryBase<Comment, BaseDbContext>, ICommentRepository
    {
        public CommentRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
