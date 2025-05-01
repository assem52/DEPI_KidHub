using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidHub.Data.Entities
{
    public class UserCourse
    {
        public Guid UserId { get; set; }

        public Guid CourseId { get; set; }

        public User? User { get; set; }
        public Course? Course { get; set; }

        public DateTime? EnrolledOn { get; set; }
        public bool? IsCompleted { get; set; }

    }


}

