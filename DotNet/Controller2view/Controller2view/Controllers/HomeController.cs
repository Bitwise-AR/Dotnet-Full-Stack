using Controller2view.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Controller2view.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ayush()
        {
            ViewBag.Message = "Hello from Controller";
            ViewBag.Number = 25;
            return View();
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
