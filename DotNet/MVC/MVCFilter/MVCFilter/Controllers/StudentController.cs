using Microsoft.AspNetCore.Mvc;
using MVCFilter.Filters;

namespace MVCFilter.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [SanitizeInputFilter]
        public IActionResult Create(string name, string email)
        {
            return View();
        }
    }
}
