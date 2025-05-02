using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidHub.Data.Entities
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? ContentType { get; set; } // "video", "article", etc.
        public string? ContentUrl { get; set; } // link to video/file/text
        public Guid? CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
