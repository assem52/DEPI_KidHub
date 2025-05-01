using KidHub.Data.Data;
using KidHub.Data.Entities;
using KidHub.Data.Repositories.MainRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidHub.Data.Repositories.CourseRepo
{
    public class CourseRepository : Repository<Course, Guid>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
        }


        // Only put course-specific methods here, like:

    }
}
