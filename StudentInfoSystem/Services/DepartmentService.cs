using StudentInfoSystem.Interfaces;
using StudentInfoSystem.Models.Entities;
using StudentInfoSystem.Models.RequestDTOs;

namespace StudentInfoSystem.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ILectureRepository _lectureRepository;

        public DepartmentService(IDepartmentRepository shopItemRepository, IStudentRepository studentRepository, ILectureRepository lectureRepository)
        {
            _departmentRepository = shopItemRepository;
            _studentRepository = studentRepository;
            _lectureRepository = lectureRepository;
        }

        public List<Department>? GetDepartments()
        {
            var departmentList = _departmentRepository.GetDepartments();

            if (departmentList.Count == 0)
            {
                return null;
            }

            return departmentList;
        }

        public Department? GetDepartmentByDepartmentId(int departmentId)
        {
            var department = _departmentRepository.GetDepartmentByDepartmentId(departmentId);

            if (department == null)
            {
                return null;
            }

            return department;
        }

        public int? InsertDepartment(InsertDepartmentRequest request)
        {
            var departmentId = _departmentRepository.InsertDepartment(request.DepartmentName);

            List<int> studentsIds = [];
            List<int> lecturesIds = [];

            foreach (var studentName in request.StudentNames)
            {
                int studentId = _studentRepository.InsertStudent(studentName, departmentId);
                studentsIds.Add(studentId);
            }

            foreach (var lectureName in request.LectureNames)
            {
                int lectureId = _lectureRepository.InsertLecture(lectureName);
                lecturesIds.Add(lectureId);

                _departmentRepository.AddDepartmentLectureRelationship(departmentId, lectureId);
            }

            foreach (var lectureId in lecturesIds)
            {
                foreach (var studentId in studentsIds)
                {
                    _studentRepository.AddStudentLectureRelationship(studentId, lectureId);
                }
            }

            return departmentId;
        }

        public bool UpdateDepartmentName(UpdateDepartmentNameRequest request)
        {
            int updatedDepartmentsCount = _departmentRepository.UpdateDepartmentName(request);


            if (updatedDepartmentsCount < 1)
            {
                return false;
            }

            return true;
        }
    }
}
