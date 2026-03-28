using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OneToManyEFMVC.Models;
using OneToManyEFMVC.Repository;

namespace OneToManyEFMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _empRepo;
        private readonly IDepartmentRepository _deptRepo;

        public EmployeeController(IEmployeeRepository empRepo, IDepartmentRepository deptRepo)
        {
            _empRepo = empRepo;
            _deptRepo = deptRepo;
        }

        public IActionResult Index()
        {
            return View(_empRepo.GetAll());
        }

        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_deptRepo.GetAll(), "DepartmentId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _empRepo.Add(employee);
            return RedirectToAction("Index");
        }
    }
}