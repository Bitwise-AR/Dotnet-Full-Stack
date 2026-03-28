using Microsoft.AspNetCore.Mvc;
using OneToOneEFMVCRepo.Models;
using OneToOneEFMVCRepo.Repository;

namespace OneToOneEFMVCRepo.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _repo.Add(user);
            return RedirectToAction("Index");
        }
    }
}