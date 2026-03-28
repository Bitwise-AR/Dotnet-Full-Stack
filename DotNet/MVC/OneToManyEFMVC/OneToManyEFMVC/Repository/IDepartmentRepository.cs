using OneToManyEFMVC.Models;

namespace OneToManyEFMVC.Repository
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        void Add(Department department);
    }
}