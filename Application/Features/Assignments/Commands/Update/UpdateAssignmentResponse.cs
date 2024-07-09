namespace Application.Features.Assignments.Commands.Update
{
    public class UpdateAssignmentResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
