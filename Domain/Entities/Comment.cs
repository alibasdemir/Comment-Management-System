using Core.Persistence;
using Core.Security.Entities;

namespace Domain.Entities
{
    public class Comment : Entity
    {
        public int AssignmentId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public virtual Assignment Assignment { get; set; }
        public virtual User User { get; set; }

        public Comment()
        {
        }

        public Comment(int id, int assignmentId, int userId, string content, Assignment assignment, User user)
            : base(id)
        {
            AssignmentId = assignmentId;
            UserId = userId;
            Content = content;
            Assignment = assignment;
            User = user;
        }
    }
}
