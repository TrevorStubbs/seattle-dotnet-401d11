
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using StudentEnrollmentAPI.Data;
using StudentEnrollmentAPI.Models;
using StudentEnrollmentAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace courseEnrollmentAPI.Models.Services
{
    public class CourseRepository : ICourse
    {
        private SchoolEnrollmentDbContext _context;

        public CourseRepository(SchoolEnrollmentDbContext context)
        {
            _context = context;
        }


        public async Task<Course> Create(Course course) // for async you need it to return a Task<T> return time
        {
            // when I have a course, I want to add them the the database.

            //_context.courses.Add(course); // old way
            _context.Entry(course).State = Microsoft.EntityFrameworkCore.EntityState.Added; // New way Clearner than old way // Added but not saved yet
            // The course gets 'saved' here, and then associated with an id.
            await _context.SaveChangesAsync(); // must await when making an async call.

            return course;
        }

        public async Task Delete(int id) // When void use Task
        {
            Course course = await GetCourse(id);
            _context.Entry(course).State = Microsoft.EntityFrameworkCore.EntityState.Deleted; // staged for deletion
            await _context.SaveChangesAsync();
        }

        public async Task<Course> GetCourse(int id)
        {
            // look in the db on the course table, where the id is equal to the id that was brought in as an argument
            Course course = await _context.Courses.FindAsync(id);

            // include all of the enrollments that the student has
            var enrollments = await _context.Enrollments.Where(x => x.CourseId == id)
                                                        .Include(x => x.Student)
                                                        .ToListAsync();
            course.Enrollments = enrollments;
            return course;
        }

        public async Task<List<Course>> GetCourses()
        {
            var courses = await _context.Courses.ToListAsync();

            return courses;
        }

        public async Task<Course> Update(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return course;
        }

        // Add a course and a student together
        public async Task AddStudent(int studentId, int courseId)
        {
            Enrollments enrollment = new Enrollments()
            {
                CourseId = courseId,
                StudentId = studentId
            };

            _context.Entry(enrollment).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveStudentFromCourse(int courseId, int studentId)
        {
            var result = await _context.Enrollments.FirstOrDefaultAsync(x => x.CourseId == courseId && x.StudentId == studentId);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
