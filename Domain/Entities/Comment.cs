using Core.Persistence;

namespace Domain.Entities
{
    public class Comment : Entity
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public virtual Task Task { get; set; }
        public virtual User User { get; set; }

        public Comment()
        {
        }

        public Comment(int id, int taskId, int userId, string content, Task task, User user)
            : base(id)
        {
            TaskId = taskId;
            UserId = userId;
            Content = content;
            Task = task;
            User = user;
        }
    }
}
