using KidHub.Data.Entities;
using KidHub.Data.Repositories.MainRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidHub.Data.Repositories.CourseRepo
{
    public interface ICourseRepository : IRepository<Course, Guid>
    {
       
    }
}
