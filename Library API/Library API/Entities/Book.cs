namespace Library_API.Entities
{
    public class Book : Entity
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int PageCount { get; set; }

        public bool IsRead { get; set; }
    }
}
