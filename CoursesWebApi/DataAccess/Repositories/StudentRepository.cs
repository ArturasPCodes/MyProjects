using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(CoursesDbContext courseDbContext) : base(courseDbContext)
        {
        }
    }
}
