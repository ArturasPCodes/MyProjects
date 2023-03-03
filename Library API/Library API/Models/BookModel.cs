namespace Library_API.Models
{
    public class BookModel
    {
        public BookModel(int id,
            string title,
            string author,
            int pageCount,
            bool isRead)
        {
            Id = id;
            Title = title;
            Author = author;
            PageCount = pageCount;
            IsRead = isRead;
        }

        public int Id { get; }
        public string Title { get; }
        public string Author { get; }
        public int PageCount { get; }
        public bool IsRead { get; }
    }
}
