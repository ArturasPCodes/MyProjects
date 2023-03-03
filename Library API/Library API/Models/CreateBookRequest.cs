namespace Library_API.Models
{
    public class CreateBookRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
        public bool IsRead { get; set; }
    }
}
