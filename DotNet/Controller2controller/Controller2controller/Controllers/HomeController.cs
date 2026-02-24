using Controller2controller.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Controller2controller.Controllers
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

        public IActionResult Send()
        {
            TempData["Message"] = "Hello from Home Controller!";
            return RedirectToAction("Receive", "Student");
        }

        public IActionResult Square(int? num)
        {
            return RedirectToAction("Index", "Square", new { num = num});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
