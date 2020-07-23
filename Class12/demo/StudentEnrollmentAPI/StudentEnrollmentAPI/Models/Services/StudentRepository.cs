using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using StudentEnrollmentAPI.Data;
using StudentEnrollmentAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollmentAPI.Models.Services
{
    public class StudentRepository : IStudent
    {

        private SchoolEnrollmentDbContext _context;

        // This is the INJECTION: It is from the DBContext file.
        public StudentRepository(SchoolEnrollmentDbContext context)
        {
            _context = context;
        }

        public async Task<Student> Create(Student student) // for async you need it to return a Task<T> return time
        {
            // when I have a student, I want to add them the the database.

            //_context.Students.Add(student); // old way
            _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Added; // New way Clearner than old way // Added but not saved yet
            // The student gets 'saved' here, and then associated with an id.
            await _context.SaveChangesAsync(); // must await when making an async call.

            return student;
        }

        public async Task Delete(int id) // When void use Task
        {
            Student student = await GetStudent(id);
            _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Deleted; // staged for deletion
            await _context.SaveChangesAsync();
        }

        public async Task<Student> GetStudent(int id)
        {
            // look in the db on the student table, where the id is equal to the id that was brought in as an argument
            Student student = await _context.Students.FindAsync(id);
            return student;
        }

        public async Task<List<Student>> GetStudents()
        {
            var students = await _context.Students.ToListAsync();

            return students;
        }

        public async Task<Student> Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return student;
        }
    }
}
