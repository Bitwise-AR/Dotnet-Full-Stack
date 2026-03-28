using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityApi.Interfaces;
using UniversityApi.Models;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructor _repo;

        public InstructorController(IInstructor repo)
        {
            _repo = repo;
        }

        [HttpPost("AddInstructor")]
        public IActionResult AddInstructor([FromBody] Instructor instructor)
        {
            var result = _repo.AddInstructor(instructor);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpGet("WithCourseCountAbove/{count}")]
        public IActionResult GetInstructorsWithCourseCountAbove(int count)
        {
            var instructors = _repo.GetInstructorsWithCourseCountAbove(count);

            if (instructors.Any())
                return Ok(instructors);

            return NotFound("No Records Found");
        }

        [HttpGet("WithMostEnrollments")]
        public IActionResult GetInstructorsWithMostEnrollments()
        {
            var instructors = _repo.GetInstructorsWithMostEnrollments();

            if (instructors.Any())
                return Ok(instructors);

            return NotFound("No Records Found");
        }
    }
}
