using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidHub.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; } // we'll hash passwords
        public string? Role { get; set; } // "Admin" or "User"
        public bool? IsPremium { get; set; } // For access levels
        public ICollection<UserCourse>? EnrolledCourses { get; set; }
    }

}
