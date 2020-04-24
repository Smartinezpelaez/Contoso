using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Repositories.Implements
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private SchoolContext schoolContext;

        public StudentRepository(SchoolContext schoolContext) : base  (schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        public async Task<IEnumerable<Course>> GetCoursesByStudent(int id)
        {
            //SQL
            //SELECT S.*
            //FROM[dbo].[Enrollment]     E
            //JOIN[dbo].[Student] S ON S.ID	=	E.StudentID
            //WHERE E.CourseID = 4022;

            //var listStudents = await schoolContext.Enrollments
            //    .Include(x => x.Student)
            //    .Where(x => x.CourseID == id)
            //    .Select(x => x.Student)
            //    .ToListAsync();

            var listCourses = await (from enrollment in schoolContext.Enrollments
                                      join course in schoolContext.Courses on enrollment.CourseID equals course.CourseID
                                      where enrollment.StudentID == id
                                      select course).ToListAsync();

            return listCourses;
        }

    }
}
