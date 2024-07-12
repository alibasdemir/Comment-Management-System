using Application.Repositories;
using Core.Security.Entities;

namespace Application.Services.OperationClaimService
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimManager(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<OperationClaim> GetById(int id)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(i => i.Id == id);
            return operationClaim;
        }

        public async Task<OperationClaim> Update(OperationClaim operationClaim)
        {
            await _operationClaimRepository.UpdateAsync(operationClaim);
            return operationClaim;
        }
    }
}
