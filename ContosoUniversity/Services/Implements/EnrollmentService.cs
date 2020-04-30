using ContosoUniversity.Models;
using ContosoUniversity.Repositories;
using ContosoUniversity.Repositories.Implements;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ContosoUniversity.Services.Implements
{
    public class EnrollmentService : GenericService<Enrollment>, IEnrollmentService
    {
        private IEnrollmetnRepository enrollmentRepository;

        public EnrollmentService(IEnrollmetnRepository enrollmetnRepository) : base(enrollmetnRepository)
        {
            this.enrollmentRepository = enrollmetnRepository;
        }

    }
}
