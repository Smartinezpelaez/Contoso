using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class Instructor
    {
        public Instructor()
        {
            CourseInstructor = new HashSet<CourseInstructor>();
            Department = new HashSet<Department>();
        }

        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime? HireDate { get; set; }

        public OfficeAssignment OfficeAssignment { get; set; }
        public ICollection<CourseInstructor> CourseInstructor { get; set; }
        public ICollection<Department> Department { get; set; }
    }
}
