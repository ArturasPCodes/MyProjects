namespace CoursesWebApi.Models
{
    public class UpdateCourseRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Hours { get; set; }
    }
}
