using Application.Features.Comments.Queries.GetById;

namespace Application.Features.Assignments.Queries.GetList
{
    public class GetListAssignmentResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public ICollection<GetByIdCommentResponse> Comments { get; set; }
    }
}
