using Core.Persistence;

namespace Domain.Entities
{
    public class Assignment : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public Assignment()
        {
            Comments = new HashSet<Comment>();
        }

        public Assignment(int id, string title, string description)
            : this()
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}
