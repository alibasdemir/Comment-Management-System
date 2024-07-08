using Core.Persistence;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IAssignmentRepository : IAsyncRepository<Assignment>, IRepository<Assignment>
    {
    }
}
