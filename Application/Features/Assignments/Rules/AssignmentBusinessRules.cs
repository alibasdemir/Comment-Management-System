using Application.Features.Assignments.Constants;
using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Assignments.Rules
{
    public class AssignmentBusinessRules : BaseBusinessRules
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentBusinessRules(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task AssignmentShouldExistWhenSelected(int id)
        {
            Assignment? result = await _assignmentRepository.GetAsync(predicate: i => i.Id == id, enableTracking: false);
            if (result == null)
            {
                throw new BusinessException(AssignmentMessages.AssignmentNotExists);
            }
        }
    }
}
