using StudentInfoSystem.Models.Entities;
using StudentInfoSystem.Models.RequestDTOs;

namespace StudentInfoSystem.Interfaces
{
    public interface IStudentService
    {
        int? InsertStudent(string name, int departmentId);

        bool UpdateStudentDepartment(UpdateStudentDepartmentRequest request);

        List<Student>? GetStudentsByDepartmentId(int id);

        Student? GetStudentByStudentId(int id);
    }
}
