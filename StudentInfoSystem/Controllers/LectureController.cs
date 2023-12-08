using Microsoft.AspNetCore.Mvc;
using Serilog;
using StudentInfoSystem.Interfaces;
using StudentInfoSystem.Models.Entities;
using StudentInfoSystem.Models.RequestDTOs;

namespace StudentInfoSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LectureController : ControllerBase
    {
        private readonly ILectureService _lectureService;
        public LectureController(ILectureService lectureService)
        {
            _lectureService = lectureService;
        }

        [HttpGet]
        public List<Lecture> GetLectures()
        {
            return _lectureService.GetLectures();
        }

        [HttpPost]
        public IActionResult InsertLecture([FromBody] InsertLectureRequest lecture)
        {
            try
            {
                var lectureId = _lectureService.InsertLecture(lecture.Name, lecture.DepartmentId);

                if (lectureId == null)
                {
                    return BadRequest();
                }

                return StatusCode(StatusCodes.Status201Created, lectureId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occured: {ErrorMessage}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected error.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetLecturesByDepartmentId(int id)
        {
            try
            {
                var lectureList = _lectureService.GetLecturesByDepartmentId(id);

                if (lectureList == null)
                {
                    return NotFound();
                }

                return Ok(lectureList);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occured: {ErrorMessage}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected error.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetLecturesByStudentId(int id)
        {
            try
            {
                var lectureList = _lectureService.GetLecturesByStudentId(id);

                if (lectureList == null)
                {
                    return NotFound();
                }

                return Ok(lectureList);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occured: {ErrorMessage}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected error.");
            }


        }
    }
}
