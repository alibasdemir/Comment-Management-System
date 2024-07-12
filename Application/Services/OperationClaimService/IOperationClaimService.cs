using Core.Security.Entities;

namespace Application.Services.OperationClaimService
{
    public interface IOperationClaimService
    {
        public Task<OperationClaim> GetById(int id);
        public Task<OperationClaim> Update(OperationClaim operationClaim);
    }
}
