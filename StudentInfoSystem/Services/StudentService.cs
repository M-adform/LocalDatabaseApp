using StudentInfoSystem.Interfaces;
using StudentInfoSystem.Models.Entities;
using StudentInfoSystem.Models.RequestDTOs;

namespace StudentInfoSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ILectureRepository _lectureRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public StudentService(IStudentRepository studentRepository, ILectureRepository lectureRepository, IDepartmentRepository departmentRepository)
        {
            _studentRepository = studentRepository;
            _lectureRepository = lectureRepository;
            _departmentRepository = departmentRepository;
        }

        public int? InsertStudent(string name, int departmentId)
        {
            int student_id = _studentRepository.InsertStudent(name, departmentId);

            List<Lecture> lectures = _lectureRepository.GetLecturesByDepartmentId(departmentId);
            foreach (Lecture lecture in lectures)
            {
                _studentRepository.AddStudentLectureRelationship(student_id, lecture.Lecture_Id);
            }

            return student_id;
        }

        public bool UpdateStudentDepartment(UpdateStudentDepartmentRequest request)
        {
            var department = _departmentRepository.GetDepartmentByDepartmentId(request.DepartmentId);

            if (department == null)
            {
                return false;
            }

            _studentRepository.UpdateStudentDepartment(request);
            _lectureRepository.DeleteLecturesByStudentId(request.Id);
            List<Lecture> lectures = _lectureRepository.GetLecturesByDepartmentId(request.DepartmentId);

            foreach (Lecture lecture in lectures)
            {
                _studentRepository.AddStudentLectureRelationship(request.Id, lecture.Lecture_Id);
            }
            return true;
        }

        public List<Student>? GetStudentsByDepartmentId(int id)
        {
            var department = _departmentRepository.GetDepartmentByDepartmentId(id);

            if (department == null)
            {
                return null;
            }

            return _studentRepository.GetStudentsByDepartmentId(id);
        }

        public Student? GetStudentByStudentId(int id)
        {
            var student = _studentRepository.GetStudentByStudentId(id);

            if (student == null)
            {
                return null;
            }

            return student;
        }
    }
}
