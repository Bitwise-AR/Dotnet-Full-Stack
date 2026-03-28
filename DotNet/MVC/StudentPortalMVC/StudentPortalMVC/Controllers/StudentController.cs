using Microsoft.AspNetCore.Mvc;
using StudentPortalMVC.Services;

namespace StudentPortalMVC.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        private readonly MarkService _markService;

        public StudentController(MarkService markService)
        {
            _markService = markService;
        }

        [HttpGet("dashboard/{id}")]
        public IActionResult Dashboard(int id)
        {
            ViewBag.StudentId = id;
            return View();
        }

        [HttpGet("marks/{id}")]
        public IActionResult Marks(int id)
        {
            var marks = _markService.GetStudentMarks(id);
            return View(marks);
        }

        [HttpGet("idcard/{id}")]
        public IActionResult IDCard(int id)
        {
            ViewBag.StudentId = id;
            return View();
        }
    }
}