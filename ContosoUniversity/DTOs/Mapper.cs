using AutoMapper;
using ContosoUniversity.Models;

namespace ContosoUniversity.DTOs
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<StudentDTO, Student>();
            CreateMap<Student, StudentDTO>();

            CreateMap<CourseDTO, Course>();
            CreateMap<Course, CourseDTO>();

            CreateMap<EnrollmentDTO, Enrollment>();
            CreateMap<Enrollment, EnrollmentDTO>();

            CreateMap<InstructorDTO, Instructor>();
            CreateMap<Instructor, InstructorDTO>();

            CreateMap<DepartmentDTO, Department>();
            CreateMap<Department, DepartmentDTO>();


            CreateMap<OfficeAssignmentDTO, OfficeAssignment>();
            CreateMap<OfficeAssignment, OfficeAssignmentDTO>();
        }
    }
}
