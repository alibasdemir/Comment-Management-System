namespace Application.Features.UserOperationClaims.Commands.Update
{
    public class UpdateUserOperationClaimResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
