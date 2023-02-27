using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class LectorRepository : BaseRepository<Lector>
    {
        public LectorRepository(CoursesDbContext courseDbContext) : base(courseDbContext)
        {
        }
    }
}
