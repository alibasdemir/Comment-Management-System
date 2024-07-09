namespace Application.Features.Assignments.Queries.GetById
{
    public class GetByIdAssignmentResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
