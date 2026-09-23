    using System;
using System.Collections.Generic;
using System.Text;

namespace Student.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
        public DateTime enrollment {  get; set; }

    }
}
