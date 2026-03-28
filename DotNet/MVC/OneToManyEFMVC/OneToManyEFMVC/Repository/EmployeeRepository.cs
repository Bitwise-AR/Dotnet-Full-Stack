using Microsoft.EntityFrameworkCore;
using OneToManyEFMVC.Data;
using OneToManyEFMVC.Models;

namespace OneToManyEFMVC.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetAll()
        {
            return _context.Employees
                .Include(e => e.Department)
                .ToList();
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
    }
}