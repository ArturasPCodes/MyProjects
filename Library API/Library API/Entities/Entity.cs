namespace Library_API.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }
}
