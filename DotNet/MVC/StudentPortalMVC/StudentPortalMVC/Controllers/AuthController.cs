using Microsoft.AspNetCore.Mvc;
using StudentPortalMVC.Models;
using StudentPortalMVC.Services;

namespace StudentPortalMVC.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly StudentService _studentService;

        public AuthController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(Student student, int Semester, int Subject1, int Subject2, int Subject3)
        {
            student.Marks = new List<Mark>()
            {
                new Mark{
                    Semester = Semester,
                    Subject1 = Subject1,
                    Subject2 = Subject2,
                    Subject3 = Subject3
                }
            };

            _studentService.Register(student);

            return RedirectToAction("Login");
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            var student = _studentService.Login(email, password);

            if (student != null)
            {
                return RedirectToAction("Dashboard", "Student", new { id = student.Id });
            }

            ViewBag.Error = "Invalid Login";
            return View();
        }
    }
}