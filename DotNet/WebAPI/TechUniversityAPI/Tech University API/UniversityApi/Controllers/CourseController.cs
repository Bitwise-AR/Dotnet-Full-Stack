using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityApi.Interfaces;
using UniversityApi.Models;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourse _repo;

        public CourseController(ICourse repo)
        {
            _repo = repo;
        }

        [HttpPut("UpdateCourse")]
        public IActionResult UpdateCourse([FromBody] Course course)
        {
            var result = _repo.UpdateCourse(course);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpGet("WithEnrollmentsAboveGrade/{grade}")]
        public IActionResult GetCoursesWithEnrollmentsAboveGrade(int grade)
        {
            var courses = _repo.GetCoursesWithEnrollmentsAboveGrade(grade);

            if (courses.Any())
                return Ok(courses);

            return NotFound("No Records Found");
        }

        [HttpGet("ByInstructorName/{instructorName}")]
        public IActionResult GetCoursesByInstructorName(string instructorName)
        {
            var courses = _repo.GetCoursesByInstructorName(instructorName);

            if (courses.Any())
                return Ok(courses);

            return NotFound("No Records Found");
        }
    }
}
