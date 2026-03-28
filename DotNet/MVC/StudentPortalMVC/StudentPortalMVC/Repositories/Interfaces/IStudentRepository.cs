using StudentPortalMVC.Models;

namespace StudentPortalMVC.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        Student GetByEmail(string email);
        Student GetById(int id);
    }
}