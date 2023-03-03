namespace Library_API.Models
{
    public class UpdateBookStatusResponse : BookModel
    {
        public UpdateBookStatusResponse(
            int id,
            string title,
            string author,
            int pageCount,
            bool isRead)
            : base(
                  id,
                  title,
                  author,
                  pageCount,
                  isRead)
        {
        }
    }
}
