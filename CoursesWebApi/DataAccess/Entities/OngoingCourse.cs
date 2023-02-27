using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class OngoingCourse : Entity
    {
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //[ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}
