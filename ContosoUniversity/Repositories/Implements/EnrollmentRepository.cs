using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Repositories.Implements
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmetnRepository
    {
        private SchoolContext schoolContext;

        public EnrollmentRepository(SchoolContext schoolContext) : base(schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        //public async Task<IActionResult> Index(int? id)
       // {
           // var schoolContext = _context.Include(e => e.Course).Include(e => e.Student);
           // return View(await schoolContext.ToListAsync());
       // }

    }
}
