using EFDbFirstMVC.Models;

namespace EFDbFirstMVC.Services
{
    public interface IStudentService
    {
        Task<List<Student>> SearchAsync(string q = null);
    }
}
