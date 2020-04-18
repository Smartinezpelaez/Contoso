using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.DTOs
{
    public class StudentDTO
    {

        public int ID { get; set; }

        [Required(ErrorMessage =("The Last Name is required"))]
        [Display(Name =("Last Name"))]
        public string LastName { get; set; }

        [Required(ErrorMessage = ("The First MidName is required"))]
        [Display(Name = ("FirstMid Name"))]
        public string FirstMidName { get; set; }

        [Required(ErrorMessage = ("The Enrollment Date is required"))]
        [Display(Name = ("Enrollment Date"))]
        public DateTime EnrollmentDate { get; set; }
    }
}
