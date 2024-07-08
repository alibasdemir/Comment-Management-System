using Application.Repositories;
using Core.Persistence;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class AssignmentRepository : EfRepositoryBase<Assignment, BaseDbContext>, IAssignmentRepository
    {
        public AssignmentRepository(BaseDbContext context) : base(context)
        {
        }
    }
}

