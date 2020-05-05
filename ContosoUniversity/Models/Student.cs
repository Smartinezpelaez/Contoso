using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class Student
    {
        public Student()
        {
            Enrollment = new HashSet<Enrollment>();
        }

        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime? EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollment { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", LastName, FirstMidName);
            }
        }
    }

    
}
