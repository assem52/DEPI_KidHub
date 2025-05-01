using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidHub.Data.Entities
{
     public class Course
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? ThumbnailUrl { get; set; }
        public decimal? Price { get; set; } // Can be 0 for free courses
        public bool? IsPremiumOnly { get; set; }

        public ICollection<UserCourse>? EnrolledUsers { get; set; }
    }

}
