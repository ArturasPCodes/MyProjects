using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OngoingCourseLineRepository : BaseRepository<OngoingCourseLine>
    {
        public OngoingCourseLineRepository(CoursesDbContext courseDbContext) : base(courseDbContext)
        {
        }
    }
}
