using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.Interfaces;
using UniversityApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace UniversityApi.Repositories
{

    public class InstructorRepository : IInstructor
    {
        private readonly UniversityContext _context;

        public InstructorRepository(UniversityContext context)
        {
            _context = context;
        }

        public bool AddInstructor(Instructor instructor)
        {
            var exists = _context.Instructors
                .Any(i => i.Name == instructor.Name);

            if (exists)
                return false;

            _context.Instructors.Add(instructor);
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<Instructor> GetInstructorsWithCourseCountAbove(int count)
        {
            return _context.InstructorCourses
                .GroupBy(ic => ic.Instructor)
                .Where(g => g.Count() > count)
                .Select(g => g.Key)
                .ToList();
        }

        public IEnumerable<Instructor> GetInstructorsWithMostEnrollments()
        {
            var instructorEnrollments = _context.InstructorCourses
                .Select(ic => new
                {
                    Instructor = ic.Instructor,
                    EnrollmentCount = ic.Course.Enrollments.Count()
                })
                .GroupBy(x => x.Instructor)
                .Select(g => new
                {
                    Instructor = g.Key,
                    Total = g.Sum(x => x.EnrollmentCount)
                })
                .ToList();

            var max = instructorEnrollments.Max(x => x.Total);

            return instructorEnrollments
                .Where(x => x.Total == max)
                .Select(x => x.Instructor)
                .ToList();
        }
    }
}
