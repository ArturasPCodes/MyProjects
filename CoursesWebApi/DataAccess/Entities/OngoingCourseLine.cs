using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class OngoingCourseLine : Entity
    {
        public int OngoingCourseId { get; set; }
        public int LectorId { get; set; }
        public int StudentId { get; set; }

        [ForeignKey("OngoingCourseId")]
        public virtual OngoingCourse OngoingCourse { get; set; }

        [ForeignKey("LectorId")]
        public virtual Lector Lector { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}
