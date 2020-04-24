using ContosoUniversity.Models;
using System;
using System.ComponentModel.DataAnnotations;


namespace ContosoUniversity.DTOs
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class EnrollmentDTO
    {
       
        public int EnrollmentID { get; set; }

        [Required(ErrorMessage = ("The CourseID is required"))]
        [Display(Name = ("CourseID"))]
        public int CourseID { get; set; }

        [Required(ErrorMessage = ("The StudentID is required"))]
        [Display(Name = ("StudentID"))]
        public int StudentID { get; set; }

        [Required(ErrorMessage = ("The Grade is required"))]
        [Display(Name = ("Grade"))]
        public Grade? Grade { get; set; }


        [Required(ErrorMessage = ("The Course is required"))]
        [Display(Name = ("Course"))]
        public Course Course { get; set; }

        [Required(ErrorMessage = ("The Student is required"))]
        [Display(Name = ("Student"))]
        public Student Student { get; set; }

    }
}
