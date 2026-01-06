using Microsoft.AspNetCore.Mvc;
using StudentAPI.Data;
using StudentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

     
        public StudentController(AppDbContext context)
        {
            _context = context;
        }

    
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _context.Students.ToListAsync();
            return Ok(students); // 200 OK
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Created("", student); 
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            var existing = await _context.Students.FindAsync(id);

            if (existing == null)
                return NotFound(); // 404

            existing.Name = student.Name;
            existing.Age = student.Age;

            await _context.SaveChangesAsync();
            return NoContent(); // 204
        }

    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound(); // 404

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return NoContent(); // 204
        }
    }
}
