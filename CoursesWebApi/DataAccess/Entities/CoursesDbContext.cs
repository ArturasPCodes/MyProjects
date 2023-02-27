using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities
{
    public class CoursesDbContext : DbContext
    {
        public CoursesDbContext(DbContextOptions<CoursesDbContext> options)
            : base(options) 
        {
            
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Lector> Lectors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<OngoingCourse> OngoingCourses { get; set; }
        public DbSet<OngoingCourseLine> OngoingCourseLines { get; set; }
    }
}
