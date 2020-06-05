using System.Collections.Generic;

namespace ContosoUniversity.Models.API
{



    public partial class Course
    {
        public Course()
        {
          //  CourseInstructor = new HashSet<CourseInstructor>();
            Enrollment = new HashSet<Enrollment>();
        }

        public int CourseID { get; set; }
        public string Title { get; set; }
        public int? Credits { get; set; }

      //  public ICollection<CourseInstructor> CourseInstructor { get; set; }
        public ICollection<Enrollment> Enrollment { get; set; }
    }
}
