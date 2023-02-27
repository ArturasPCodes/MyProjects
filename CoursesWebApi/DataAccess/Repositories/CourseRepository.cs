using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CourseRepository : BaseRepository<Course>
    {
        public CourseRepository(CoursesDbContext courseDbContext) : base(courseDbContext)
        {
        }
    }
}
