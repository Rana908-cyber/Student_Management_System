using System;
using System.Collections.Generic;
using System.Text;

namespace Student.Models
{
    public class Student1 : User
    {
        public string University { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
