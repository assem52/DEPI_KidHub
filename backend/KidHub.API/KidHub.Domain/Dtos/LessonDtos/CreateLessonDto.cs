using KidHub.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidHub.Domain.Dtos.LessonDtos
{
    public class CreateLessonDto
    {
        public string Title { get; set; }
        public string ContentType { get; set; } // "video", "article", etc.
        public string ContentUrl { get; set; } // link to video/file/text
        public Guid CourseId { get; set; }
    }
}
