using StudentInfoSystem.Models.Entities;
using StudentInfoSystem.Models.RequestDTOs;

namespace StudentInfoSystem.Interfaces
{
    public interface IDepartmentService
    {
        List<Department>? GetDepartments();

        Department? GetDepartmentByDepartmentId(int departmentId);

        int? InsertDepartment(InsertDepartmentRequest request);

        bool UpdateDepartmentName(UpdateDepartmentNameRequest request);
    }
}
