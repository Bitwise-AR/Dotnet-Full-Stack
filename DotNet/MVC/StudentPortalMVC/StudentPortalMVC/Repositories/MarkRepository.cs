using StudentPortalMVC.Data;
using StudentPortalMVC.Models;
using StudentPortalMVC.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StudentPortalMVC.Repositories
{
    public class MarkRepository : IMarkRepository
    {
        private readonly ApplicationDbContext _context;

        public MarkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Mark> GetMarksByStudent(int studentId)
        {
            return _context.Marks
                .Where(x => x.StudentId == studentId)
                .ToList();
        }
    }
}