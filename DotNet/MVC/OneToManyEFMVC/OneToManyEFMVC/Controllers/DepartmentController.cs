using Microsoft.AspNetCore.Mvc;
using OneToManyEFMVC.Models;
using OneToManyEFMVC.Repository;

namespace OneToManyEFMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentController(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var departments = _repository.GetAll();
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            _repository.Add(department);
            return RedirectToAction("Index");
        }
    }
}