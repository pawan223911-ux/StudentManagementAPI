using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // In-memory data store pre-populated with sample records
        private static List<Student> _students = new List<Student>
        {
            new Student
            {
                Id = 1,
                EnrollmentNo = "92500120142",
                FullName = "Janapala Pavankumar",
                Department = "Computer Engineering",
                Semester = 5
            },
            new Student
            {
                Id = 2,
                EnrollmentNo = "92500120143",
                FullName = "Aarav Patel",
                Department = "Information Technology",
                Semester = 5
            }
        };

        // GET: api/students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            return Ok(_students);
        }

        // GET: api/students/1
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound(new { Message = $"Student with ID {id} not found." });
            }
            return Ok(student);
        }

        // POST: api/students
        [HttpPost]
        public ActionResult<Student> CreateStudent([FromBody] Student newStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            newStudent.Id = _students.Count > 0 ? _students.Max(s => s.Id) + 1 : 1;
            _students.Add(newStudent);

            return CreatedAtAction(nameof(GetStudentById), new { id = newStudent.Id }, newStudent);
        }

        // PUT: api/students/1
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            var existingStudent = _students.FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return NotFound(new { Message = $"Student with ID {id} not found." });
            }

            existingStudent.EnrollmentNo = updatedStudent.EnrollmentNo;
            existingStudent.FullName = updatedStudent.FullName;
            existingStudent.Department = updatedStudent.Department;
            existingStudent.Semester = updatedStudent.Semester;

            return Ok(new { Message = "Student record updated successfully.", Data = existingStudent });
        }

        // DELETE: api/students/1
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound(new { Message = $"Student with ID {id} not found." });
            }

            _students.Remove(student);
            return Ok(new { Message = $"Student with ID {id} deleted successfully." });
        }
    }
}
