using StudentInfoSystem.Models.Entities;
using StudentInfoSystem.Models.RequestDTOs;

namespace StudentInfoSystem.Interfaces
{
    public interface IDepartmentRepository
    {
        List<Department> GetDepartments();

        Department GetDepartmentByDepartmentId(int departmentId);

        int InsertDepartment(string name);

        int UpdateDepartmentName(UpdateDepartmentNameRequest request);

        int AddDepartmentLectureRelationship(int departmentId, int lectureId);

        int DeleteDepartmentLectureRelationship(int departmentId, int lectureId);
    }
}
