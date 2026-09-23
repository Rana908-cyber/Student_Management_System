using System;
using System.Collections.Generic;
using System.Text;

namespace Student.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructor {  get; set;}
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
