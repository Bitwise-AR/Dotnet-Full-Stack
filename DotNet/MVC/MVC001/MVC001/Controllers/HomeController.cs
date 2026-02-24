using Microsoft.AspNetCore.Mvc;
using MVC001.Models;
using System.Diagnostics;

namespace MVC001.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Student()
        {
            var s = new {Name = "Ravi", Marks = 90};
            return Json(s);
        }

        public IActionResult Test()
        {
            return NotFound();
        }

        public IActionResult Square(int? number)
        {
            if (number == null)
                return Content("Please provide a number");
            
            return View(number.Value);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
