using StudentInfoSystem.Interfaces;
using StudentInfoSystem.Models.Entities;

namespace StudentInfoSystem.Services
{
    public class LectureService : ILectureService
    {
        private readonly ILectureRepository _lectureRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IStudentRepository _studentRepository;

        public LectureService(ILectureRepository lectureRepository, IDepartmentRepository departmentRepository, IStudentRepository studentRepository)
        {
            _lectureRepository = lectureRepository;
            _departmentRepository = departmentRepository;
            _studentRepository = studentRepository;
        }

        public List<Lecture>? GetLectures()
        {
            var lectureList = _lectureRepository.GetLectures();

            if (lectureList.Count == 0)
            {
                return null;
            }

            return lectureList;
        }

        public int? InsertLecture(string name, int departmentId)
        {
            int lectureId = _lectureRepository.InsertLecture(name);

            _departmentRepository.AddDepartmentLectureRelationship(departmentId, lectureId);

            return lectureId;
        }

        public List<Lecture>? GetLecturesByDepartmentId(int departmentId)
        {
            var department = _departmentRepository.GetDepartmentByDepartmentId(departmentId);

            if (department == null)
            {
                return null;
            }

            return _lectureRepository.GetLecturesByDepartmentId(departmentId);
        }

        public List<Lecture>? GetLecturesByStudentId(int studentId)
        {
            var student = _studentRepository.GetStudentByStudentId(studentId);

            if (student == null)
            {
                return null;
            }

            return _lectureRepository.GetLecturesByStudentId(studentId);
        }
    }
}
