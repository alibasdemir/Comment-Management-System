using Domain.Entities;

namespace Application.Services.AssignmentService
{
    public interface IAssignmentService
    {
        public Task<Assignment> GetById(int id);
        public Task<Assignment> Update(Assignment assignment);
    }
}
