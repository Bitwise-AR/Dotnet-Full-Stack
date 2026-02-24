using Microsoft.AspNetCore.Mvc;

namespace Controller2controller.Controllers
{
    public class SquareController : Controller
    {
        public IActionResult Index(int? num)
        {
            int result = num.Value * num.Value;
            return Content("Square = " + result);
        }
    }
}
