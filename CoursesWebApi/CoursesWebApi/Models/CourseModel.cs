namespace CoursesWebApi.Models
{
    public class CourseModel
    {
        public CourseModel(
            int id,
            string title,
            string description,
            double price,
            int hours)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            Hours = hours;
        }

        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public double Price { get; }
        public int Hours { get; }

    }
}
