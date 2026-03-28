using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityApi.Interfaces;
using UniversityApi.Models;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _repo;

        public StudentController(IStudent repo)
        {
            _repo = repo;
        }

        [HttpDelete("DeleteStudent/{studentId}")]
        public IActionResult DeleteStudent(int studentId)
        {
            var result = _repo.DeleteStudent(studentId);

            if (result)
                return Ok();

            return NotFound("No Records Found");
        }

        [HttpGet("ByCourseTitle/{courseTitle}")]
        public IActionResult GetStudentsByCourseTitle(string courseTitle)
        {
            var students = _repo.GetStudentsByCourseTitle(courseTitle);

            if (students.Any())
                return Ok(students);

            return NotFound("No Records Found");
        }
    }
}
