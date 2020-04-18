using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Repositories.Implementation;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Repositories.Implements
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private SchoolContext schoolContext;
      
       
        public CourseRepository(SchoolContext schoolContext) : base(schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        public new async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("The entiti is null");
            var flag = schoolContext.Enrollments.Any(x => x.CourseID == id);

            if (flag)
                throw new Exception("The Course have enrollments");

            schoolContext.Courses.Remove(entity);
            await schoolContext.SaveChangesAsync();

        }
    }
}
