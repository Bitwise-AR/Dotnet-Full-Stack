using StudentPortalMVC.Models;
using StudentPortalMVC.Repositories.Interfaces;
using System.Collections.Generic;

namespace StudentPortalMVC.Services
{
    public class MarkService
    {
        private readonly IMarkRepository _markRepo;

        public MarkService(IMarkRepository markRepo)
        {
            _markRepo = markRepo;
        }

        public List<Mark> GetStudentMarks(int studentId)
        {
            return _markRepo.GetMarksByStudent(studentId);
        }
    }
}