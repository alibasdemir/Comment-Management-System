using Core.Persistence;

namespace Domain.Entities
{
    public class Task : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Task()
        {
        }

        public Task(int id, string title, string description)
            : base(id)
        {
            Title = title;
            Description = description;
        }
    }
}
