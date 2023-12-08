using StudentInfoSystem.Models.Entities;
using StudentInfoSystem.Models.RequestDTOs;

namespace StudentInfoSystem.Interfaces
{
    public interface IStudentRepository
    {
        int InsertStudent(string name, int department_id);

        int AddStudentLectureRelationship(int studentId, int lectureId);

        void UpdateStudentDepartment(UpdateStudentDepartmentRequest request);

        List<Student> GetStudentsByDepartmentId(int id);

        Student? GetStudentByStudentId(int id);
    }
}
