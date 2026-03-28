using Microsoft.AspNetCore.Mvc;
using StudentDTOAPI.Models;
using StudentDTOAPI.DTO;

namespace StudentDTOAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>();

        // CREATE STUDENT
        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDTO dto)
        {
            var student = new Student
            {
                Id = dto.Id,
                Name = dto.Name,
                Age = dto.Age
            };

            students.Add(student);

            return Ok(student);
        }

        // UPDATE MARKS
        [HttpPut]
        public IActionResult UpdateStudent(UpdateStudentDTO dto)
        {
            var student = students.FirstOrDefault(x => x.Id == dto.Id);

            if (student == null)
                return NotFound("Student not found");

            student.M1 = dto.M1;
            student.M2 = dto.M2;

            if (dto.M1.HasValue && dto.M2.HasValue)
            {
                student.Total = dto.M1 + dto.M2;

                if (student.Total >= 90)
                    student.Grade = 'A';
                else if (student.Total >= 75)
                    student.Grade = 'B';
                else if (student.Total >= 50)
                    student.Grade = 'C';
                else
                    student.Grade = 'F';
            }

            return Ok(student);
        }

        // GET RESULT BY ID
        [HttpGet("{id}")]
        public IActionResult GetResultsById(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound("Student not found");

            var response = new ResultResponseDTO
            {
                Id = student.Id,
                Name = student.Name,
                M1 = student.M1,
                M2 = student.M2,
                Total = student.Total,
                Grade = student.Grade
            };

            return Ok(response);
        }
    }
}