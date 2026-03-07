using EFDbFirstMVC.Models;

namespace EFDbFirstMVC.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync(string q = null);
    }
}
