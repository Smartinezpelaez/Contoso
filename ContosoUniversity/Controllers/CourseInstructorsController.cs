using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Controllers
{
    public class CourseInstructorsController : Controller
    {
        private readonly SchoolContext _context;

        public CourseInstructorsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: CourseInstructors
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.CourseInstructor.Include(c => c.Course).Include(c => c.Instructor);
            return View(await schoolContext.ToListAsync());
        }

        // GET: CourseInstructors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseInstructor = await _context.CourseInstructor
                .Include(c => c.Course)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (courseInstructor == null)
            {
                return NotFound();
            }

            return View(courseInstructor);
        }

        // GET: CourseInstructors/Create
        public IActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID");
            ViewData["InstructorID"] = new SelectList(_context.Instructor, "ID", "ID");
            return View();
        }

        // POST: CourseInstructors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CourseID,InstructorID")] CourseInstructor courseInstructor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseInstructor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", courseInstructor.CourseID);
            ViewData["InstructorID"] = new SelectList(_context.Instructor, "ID", "ID", courseInstructor.InstructorID);
            return View(courseInstructor);
        }

        // GET: CourseInstructors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseInstructor = await _context.CourseInstructor.FindAsync(id);
            if (courseInstructor == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", courseInstructor.CourseID);
            ViewData["InstructorID"] = new SelectList(_context.Instructor, "ID", "ID", courseInstructor.InstructorID);
            return View(courseInstructor);
        }

        // POST: CourseInstructors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CourseID,InstructorID")] CourseInstructor courseInstructor)
        {
            if (id != courseInstructor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseInstructor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseInstructorExists(courseInstructor.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", courseInstructor.CourseID);
            ViewData["InstructorID"] = new SelectList(_context.Instructor, "ID", "ID", courseInstructor.InstructorID);
            return View(courseInstructor);
        }

        // GET: CourseInstructors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseInstructor = await _context.CourseInstructor
                .Include(c => c.Course)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (courseInstructor == null)
            {
                return NotFound();
            }

            return View(courseInstructor);
        }

        // POST: CourseInstructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseInstructor = await _context.CourseInstructor.FindAsync(id);
            _context.CourseInstructor.Remove(courseInstructor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseInstructorExists(int id)
        {
            return _context.CourseInstructor.Any(e => e.ID == id);
        }
    }
}
