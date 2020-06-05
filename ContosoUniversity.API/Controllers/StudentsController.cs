using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.Models.API;
using ContosoUniversity.DTOs.API;
using ContosoUniversity.API;
using ContosoUniversity.Data.API;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly SchoolContext schoolContext;

         public StudentsController (SchoolContext schoolContext)
         {
            this.schoolContext = schoolContext;
            
         }

       [HttpGet]
           public async Task<IActionResult> GetALL()
           {
            var listStudents = await schoolContext.Students.ToListAsync();
            var listStudentsDTO = listStudents.Select(x=> StudentToDto(x));
            

           return Ok(listStudentsDTO);   
           }

        /// <summary>
        /// Obtiene un Objeto de estudiante por su id.
        /// </summary>
        /// <remark>
        /// Aqui una descripcion larga si nfuera necesaria. Obtiene un objeto estudiante por su id.
        /// </remark>
        /// <param name="id">id (GUID) del objeto </param>
        /// <response code ="200">OK. Devuelve el objeto solicitado </response>
        /// <response code ="404">Not Found. No se encontro el objeto solicitado </response>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await schoolContext.Students.FirstOrDefaultAsync(x=> x.ID == id);

            if (student == null)
                return NotFound();

            var studentDTO = StudentToDto(student);

            return Ok(studentDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentDTO studentDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var student = new Student
                {
                   
                    LastName = studentDTO.LastName,
                    FirstMidName = studentDTO.FirstMidName,
                    EnrollmentDate = studentDTO.EnrollmentDate,
                };
                await schoolContext.Students.AddAsync(student);
                await schoolContext.SaveChangesAsync();

                return Ok(StudentToDto(student));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int? id, StudentDTO studentDTO)
        {
            try
            {
                if (id != studentDTO.ID)
                    return BadRequest();
                var student = await schoolContext.Students.FindAsync(id);
                student.LastName = studentDTO.LastName;
                student.FirstMidName = studentDTO.FirstMidName;
                student.EnrollmentDate = studentDTO.EnrollmentDate;

                if (!ModelState.IsValid)
                    return BadRequest();

               
                await schoolContext.Students.AddAsync(student);
                await schoolContext.SaveChangesAsync();

                return Ok(StudentToDto(student));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int? id)
        {
            try
            {
                if (id == null)
                    return NotFound();

                var student = await schoolContext.Students.FindAsync(id);
                schoolContext.Students.Remove(student);


                await schoolContext.Students.AddAsync(student);
                await schoolContext.SaveChangesAsync();

                return Ok(StudentToDto(student));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }




        private static StudentDTO StudentToDto(Student student) => new StudentDTO
        {
            ID = student.ID,
            LastName = student.LastName,
            FirstMidName = student.FirstMidName,
            EnrollmentDate = student.EnrollmentDate,
        };

        






    }
}