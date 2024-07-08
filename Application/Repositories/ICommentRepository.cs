using Core.Persistence;
using Domain.Entities;

namespace Application.Repositories
{
    public interface ICommentRepository : IAsyncRepository<Comment> , IRepository<Comment>
    {
    }
}
