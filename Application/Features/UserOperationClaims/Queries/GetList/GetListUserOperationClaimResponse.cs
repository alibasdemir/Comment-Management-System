namespace Application.Features.UserOperationClaims.Queries.GetList
{
    public class GetListUserOperationClaimResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
