using StudentPortalMVC.Data;
using StudentPortalMVC.Models;
using StudentPortalMVC.Repositories.Interfaces;
using System.Linq;

namespace StudentPortalMVC.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public Student GetByEmail(string email)
        {
            return _context.Students.FirstOrDefault(x => x.Email == email);
        }

        public Student GetById(int id)
        {
            return _context.Students.FirstOrDefault(x => x.Id == id);
        }
    }
}