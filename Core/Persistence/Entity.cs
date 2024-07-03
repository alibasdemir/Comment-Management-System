namespace Core.Persistence
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Entity()
        {
            Id = default!;
        }

        public Entity(int id)
        {
            Id = id;
        }
    }
}
