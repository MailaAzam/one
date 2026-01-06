using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        // In-memory list (NO DATABASE)
        private static List<Student> students = new List<Student>()
        {
            new Student { Id = 1, Name = "Rahul", Age = 20 },
            new Student { Id = 2, Name = "Priya", Age = 21 }
        };

    
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(students); // 200 OK
        }



        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            student.Id = students.Count + 1;
            students.Add(student);
            return Created("", student); 





        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            var existing = students.FirstOrDefault(s => s.Id == id);

            if (existing == null)
                return NotFound(); 

            existing.Name = student.Name;
            existing.Age = student.Age;

            return NoContent(); 
        }

     
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound(); 
            students.Remove(student);
            return NoContent(); 
        }
    }

    
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }
    }
}
}