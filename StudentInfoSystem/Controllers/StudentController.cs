using Microsoft.AspNetCore.Mvc;
using Serilog;
using StudentInfoSystem.Interfaces;
using StudentInfoSystem.Models.RequestDTOs;

namespace StudentInfoSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public IActionResult InsertStudent([FromBody] InsertStudentRequest student)
        {
            try
            {
                var student_id = _studentService.InsertStudent(student.StudentName, student.DepartmentId);

                if (student_id == null)
                {
                    return BadRequest();
                }

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occured: {ErrorMessage}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPut]
        public IActionResult UpdateStudentDepartment([FromBody] UpdateStudentDepartmentRequest student)
        {
            try
            {
                var studentUpdated = _studentService.UpdateStudentDepartment(student);

                if (!studentUpdated)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occured: {ErrorMessage}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentsByDepartmentId(int id)
        {
            try
            {
                var student = _studentService.GetStudentByStudentId(id);

                if (student == null)
                {
                    return NotFound();
                }

                return Ok(_studentService.GetStudentsByDepartmentId(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occured: {ErrorMessage}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
