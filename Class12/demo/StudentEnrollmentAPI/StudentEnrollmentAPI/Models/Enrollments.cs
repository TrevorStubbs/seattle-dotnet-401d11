using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollmentAPI.Models
{
    public class Enrollments
    {
        // our compostie key is the the combo of these
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        // Navigation property
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
