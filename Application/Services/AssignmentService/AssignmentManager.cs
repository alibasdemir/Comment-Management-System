using Application.Repositories;
using Domain.Entities;

namespace Application.Services.AssignmentService
{
    public class AssignmentManager : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentManager(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<Assignment> GetById(int id)
        {
            Assignment? assignment = await _assignmentRepository.GetAsync(i => i.Id == id);
            return assignment;
        }

        public async Task<Assignment> Update(Assignment assignment)
        {
            await _assignmentRepository.UpdateAsync(assignment);
            return assignment;
        }
    }
}
