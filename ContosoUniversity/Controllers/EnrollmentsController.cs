using ContosoUniversity.Models;
using ContosoUniversity.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContosoUniversity.Controllers
{

    public class EnrollmentsController : Controller
        {

            public EnrollmentsController(IEnrollmentService enrollmentService,
               IStudentService studentService,
               ICourseService courseService)
            {
                this.enrollmentService = enrollmentService;
                this.studentService = studentService;
                this.courseService = courseService;
            }
            //private readonly SchoolContext _context;
            private IEnrollmentService enrollmentService;
            private IStudentService studentService;
            private ICourseService courseService;




            //public EnrollmentsController(SchoolContext context)
            //{
            //   _context = context;

            // }


            public async Task<IActionResult> Index()
            {
                var listEnrollments = await enrollmentService.GetAll();

                return View(listEnrollments);
            }


            public async Task<ActionResult> Create()
            {
                ViewBag.Courses = await courseService.GetAll();
                ViewBag.Students = await studentService.GetAll();

                return View();
            }

            [HttpPost]
            public async Task<ActionResult> Create(Enrollment model)
            {
                if (!ModelState.IsValid)
                    return View(model);
                await enrollmentService.Insert(model);

                return RedirectToAction("Index");
            }


        }
    
}