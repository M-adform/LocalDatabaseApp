using Microsoft.AspNetCore.Mvc;
using Serilog;
using StudentInfoSystem.Interfaces;
using StudentInfoSystem.Models.RequestDTOs;

namespace StudentInfoSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            try
            {
                var departmentsList = _departmentService.GetDepartments();

                if (departmentsList == null)
                {
                    return NotFound();
                }

                return Ok(departmentsList);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occured: {ErrorMessage}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult InsertDepartment([FromBody] InsertDepartmentRequest request)
        {
            try
            {
                var departmentId = _departmentService.InsertDepartment(request);

                if (departmentId == null)
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
        public IActionResult UpdateDepartmentName([FromBody] UpdateDepartmentNameRequest request)
        {
            try
            {
                var departmentUpdated = _departmentService.UpdateDepartmentName(request);

                if (!departmentUpdated)
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
    }
}
