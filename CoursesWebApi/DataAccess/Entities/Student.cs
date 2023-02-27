namespace DataAccess.Entities
{
    public class Student : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime Birthday { get; set; }
    }
}
