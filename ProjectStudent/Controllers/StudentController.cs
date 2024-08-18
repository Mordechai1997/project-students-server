using Microsoft.AspNetCore.Mvc;
using ProjectStudent.Models;
using ProjectStudent.Services;

namespace ProjectStudent.Controllers
{
    [ApiController]
    [Route("api")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("students")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            try
            {
                var students = await _studentService.GetStudentsAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("students")]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdStudent = await _studentService.CreateStudentAsync(student);
                return CreatedAtAction(nameof(GetStudents), new { id = createdStudent.ID }, createdStudent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
