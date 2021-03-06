﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using StudentEnrollmentAPI.Data;
using StudentEnrollmentAPI.Models;
using StudentEnrollmentAPI.Models.Interfaces;

namespace StudentEnrollmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudent _student;

        // our constructor is bringing in a reference to our db
        public StudentsController(IStudent student)
        {
            _student = student;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
<<<<<<< HEAD
            List<Student> students = await _student.GetStudents();
            return students;
=======
            return await _student.GetStudents();
>>>>>>> 3b12b97f7570b6e082f7f765d9c30e1eb47e02d0
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            Student student = await _student.GetStudent(id);
            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if(id != student.Id)
            {
                return BadRequest();
            }
            var updatedStudent = await _student.Update(student);

<<<<<<< HEAD
            var updatedStudent = await _student.Update(student);

=======
>>>>>>> 3b12b97f7570b6e082f7f765d9c30e1eb47e02d0
            return Ok(updatedStudent);
        }

        // POST: api/Students
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            await _student.Create(student);
<<<<<<< HEAD

=======
>>>>>>> 3b12b97f7570b6e082f7f765d9c30e1eb47e02d0
            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            await _student.Delete(id);
<<<<<<< HEAD

            return NoContent();

        }

=======
            return NoContent();
        }
>>>>>>> 3b12b97f7570b6e082f7f765d9c30e1eb47e02d0
    }
}
