using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.Interfaces;
using UniversityApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace UniversityApi.Repositories
{

    public class StudentRepository : IStudent
    {
        private readonly UniversityContext _context;

        public StudentRepository(UniversityContext context)
        {
            _context = context;
        }

        public bool DeleteStudent(int studentId)
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentId == studentId);

            if (student == null)
                return false;

            _context.Students.Remove(student);
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<Student> GetStudentsByCourseTitle(string courseTitle)
        {
            return _context.Enrollments
                .Where(e => e.Course.Title == courseTitle)
                .Select(e => e.Student)
                .Distinct()
                .ToList();
        }
    }
}
