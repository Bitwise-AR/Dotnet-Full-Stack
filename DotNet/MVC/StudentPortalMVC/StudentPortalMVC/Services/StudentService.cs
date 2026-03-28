using StudentPortalMVC.Models;
using StudentPortalMVC.Repositories.Interfaces;

namespace StudentPortalMVC.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _studentRepo;

        public StudentService(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public void Register(Student student)
        {
            _studentRepo.AddStudent(student);
        }

        public Student Login(string email, string password)
        {
            var student = _studentRepo.GetByEmail(email);

            if (student != null && student.Password == password)
                return student;

            return null;
        }
    }
}