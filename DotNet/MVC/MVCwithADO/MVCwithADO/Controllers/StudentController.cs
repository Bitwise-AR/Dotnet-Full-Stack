using Microsoft.AspNetCore.Mvc;
using MVCwithADO.Data;

namespace MVCwithADO.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _repository;

        public StudentController(StudentRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var students = _repository.GetAllStudents();
            foreach (var s in students)
                s.Square = s.Age * s.Age;
            return View(students);
        }
    }
}
