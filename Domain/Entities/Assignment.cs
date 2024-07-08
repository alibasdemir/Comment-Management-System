using Core.Persistence;

namespace Domain.Entities
{
    public class Assignment : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Assignment()
        {
        }

        public Assignment(int id, string title, string description)
            : base(id)
        {
            Title = title;
            Description = description;
        }
    }
}
