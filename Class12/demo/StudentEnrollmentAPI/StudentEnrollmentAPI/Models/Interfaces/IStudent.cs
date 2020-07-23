using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollmentAPI.Models.Interfaces
{
    public interface IStudent
    {
<<<<<<< HEAD
        // contain methods and properties that are required for the classes to implement
=======
        //contain methods and properties that are required for the classes to implement
>>>>>>> 3b12b97f7570b6e082f7f765d9c30e1eb47e02d0

        // Create
        Task<Student> Create(Student student);

        // Read
        // Get All
        Task<List<Student>> GetStudents();
<<<<<<< HEAD
=======

>>>>>>> 3b12b97f7570b6e082f7f765d9c30e1eb47e02d0
        // Get individually (by Id)
        Task<Student> GetStudent(int id);

        // Update
        Task<Student> Update(Student student);

        // Delete
        Task Delete(int id);
    }
}
