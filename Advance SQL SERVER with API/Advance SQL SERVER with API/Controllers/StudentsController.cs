using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Advance_SQL_SERVER_with_API.Data;
using Serilog;

namespace Advance_SQL_SERVER_with_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDBcontext _context;

        // Constructor injection to get an instance of StudentDBcontext
        public StudentsController(StudentDBcontext context)
        {
            _context = context;
        }

        // GET: api/Students
        // Get all students
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Student>>> Getstudents()
        {
            // Retrieve all students from the database
            return await _context.students.ToListAsync();
        }

        // GET: api/Students/5
        // Get a single student by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            // Find a student by id
            var student = await _context.students.FindAsync(id);

            if (student == null)
            {
                // If the student is not found, return 404 NotFound
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // Update a student
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutStudent(Guid id, Student student)
        {
            // Check if the id in the route matches the id in the student object
            if (id != student.id)
            {
                // If not, return 400 BadRequest
                return BadRequest();
            }

            // Set the state of the student object to Modified
            _context.Entry(student).State = EntityState.Modified;

            try
            {
                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // If a concurrency exception occurs, check if the student exists
                if (!StudentExists(id))
                {
                    // If not, return 404 NotFound
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        // Create a new student
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            // Add the new student to the database
            _context.students.Add(student);
            await _context.SaveChangesAsync();

            // Return 201 Created with the created student
            return CreatedAtAction("GetStudent", new { id = student.id }, student);
        }

        // DELETE: api/Students/5
        // Delete a student by id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            // Find the student by id
            var student = await _context.students.FindAsync(id);
            if (student == null)
            {
                // If the student is not found, return 404 NotFound
                return NotFound();
            }

            // Remove the student from the database
            _context.students.Remove(student);
            await _context.SaveChangesAsync();

            // Return 200 OK
            return NoContent();
        }

        // Check if a student exists by id
        private bool StudentExists(Guid id)
        {
            return _context.students.Any(e => e.id == id);
        }
    }
}
