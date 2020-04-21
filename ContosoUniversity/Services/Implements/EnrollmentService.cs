using ContosoUniversity.Models;
using ContosoUniversity.Repositories;

namespace ContosoUniversity.Services.Implements
{
    public class EnrollmentService : GenericService<Enrollment>, IEnrollmentService
    {
        private IEnrollmentRepository enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository) : base(enrollmentRepository)
        {

            this.enrollmentRepository = enrollmentRepository;
        }

    }
}
