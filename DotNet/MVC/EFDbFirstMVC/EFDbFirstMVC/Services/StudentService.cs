using EFDbFirstMVC.Models;
using EFDbFirstMVC.Repositories;

namespace EFDbFirstMVC.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _repo;
        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }
        public Task<List<Student>> SearchAsync(string q = null) => _repo.GetAllAsync(q);
    }
}
