namespace Application.Features.Comments.Commands.Create
{
    public class CreateCommentResponse
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
