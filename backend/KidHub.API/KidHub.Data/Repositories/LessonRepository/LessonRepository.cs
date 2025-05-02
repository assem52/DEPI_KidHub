using KidHub.Data.Data;
using KidHub.Data.Entities;
using KidHub.Data.Repositories.MainRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidHub.Data.Repositories.LessonRepository
{
    public class LessonRepository : Repository<Lesson,  Guid>, ILessonRepository
    {
        public LessonRepository(ApplicationDbContext context) : base(context)
        {
        }
        // Only put lesson-specific methods here, like:
        // public IEnumerable<Lesson> GetLessonsByCourseId(Guid courseId)
        // {
        //     return _context.Lessons.Where(l => l.CourseId == courseId).ToList();
        // }
    }
}
