using OneToManyEFMVC.Models;

namespace OneToManyEFMVC.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        void Add(Employee employee);
    }
}