using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.Models;

namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Arun", Marks = 80 },
                new Student { Id = 2, Name = "Bala", Marks = 60 },
                new Student { Id = 3, Name = "Charan", Marks = 90 }
            };

            return Ok(students);
        }
        
        [HttpGet("add")]
        public IActionResult AddThreeNumbers(int a, int b, int c)
        {
            int sum = a + b + c;
            return Ok(sum);
        }
    }
}
