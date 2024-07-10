namespace Application.Features.Comments.Commands.Update
{
    public class UpdateCommentResponse
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
