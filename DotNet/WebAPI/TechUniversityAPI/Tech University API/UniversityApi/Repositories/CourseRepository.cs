using UniversityApi.Data;
using UniversityApi.Interfaces;
using UniversityApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace UniversityApi.Repositories
{

    public class CourseRepository : ICourse
    {
        private readonly UniversityContext _context;

        public CourseRepository(UniversityContext context)
        {
            _context = context;
        }

        public bool UpdateCourse(Course course)
        {
            var existing = _context.Courses.FirstOrDefault(c => c.CourseId == course.CourseId);

            if (existing == null)
                return false;

            existing.Title = course.Title;

            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Course> GetCoursesWithEnrollmentsAboveGrade(int grade)
        {
            return _context.Courses
                .Where(c => c.Enrollments.Any(e => e.Grade > grade))
                .ToList();
        }

        public IEnumerable<Course> GetCoursesByInstructorName(string instructorName)
        {
            var courses = _context.InstructorCourses
                .Where(ic => ic.Instructor.Name == instructorName)
                .Select(ic => ic.Course)
                .Distinct()
                .ToList();

            return courses;
        }
    }
}
