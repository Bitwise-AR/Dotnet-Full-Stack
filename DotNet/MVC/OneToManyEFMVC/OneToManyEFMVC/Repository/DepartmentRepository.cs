using Microsoft.EntityFrameworkCore;
using OneToManyEFMVC.Data;
using OneToManyEFMVC.Models;

namespace OneToManyEFMVC.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Department> GetAll()
        {
            return _context.Departments
                   .Include(d => d.Employees)
                   .ToList();
        }

        public void Add(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }
    }
}