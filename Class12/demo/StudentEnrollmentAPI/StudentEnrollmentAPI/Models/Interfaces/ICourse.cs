using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollmentAPI.Models.Interfaces
{
    public interface ICourse
    {
        // Create
        Task<Course> Create(Course course);

        // Read
        // Get All
        Task<List<Course>> GetCourses();

        Task<Course> GetCourse(int id);

        // Update
        Task<Course> Update(Course course);

        // Delete
        Task Delete(int id);

        // This is for the join table
        Task AddStudent(int studentId, int courseId);
    }
}
