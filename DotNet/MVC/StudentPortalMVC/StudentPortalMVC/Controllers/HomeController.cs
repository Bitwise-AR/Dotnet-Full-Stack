using Microsoft.AspNetCore.Mvc;

namespace StudentPortalMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}