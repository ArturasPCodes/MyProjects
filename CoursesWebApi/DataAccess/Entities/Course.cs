namespace DataAccess.Entities
{
    public class Course : Entity
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Hours{ get; set; }
        public string Description { get; set; }
    }
}
