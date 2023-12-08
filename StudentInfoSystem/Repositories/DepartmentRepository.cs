using Dapper;
using StudentInfoSystem.Interfaces;
using StudentInfoSystem.Models.Entities;
using StudentInfoSystem.Models.RequestDTOs;
using System.Data;

namespace StudentInfoSystem.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _dbConnection;
        public DepartmentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<Department> GetDepartments()
        {
            string query = "SELECT * FROM departments;";
            return _dbConnection.Query<Department>(query).ToList();
        }

        public Department GetDepartmentByDepartmentId(int departmentId)
        {
            string query = "SELECT * FROM departments WHERE department_id = @departmentId;";
            var queryArguments = new
            {
                departmentId,
            };

            return _dbConnection.QuerySingle<Department>(query, queryArguments);
        }

        public int InsertDepartment(string departmentName)
        {
            string query = "INSERT INTO departments (department_Name) VALUES (@name) RETURNING department_id";
            var queryArguments = new
            {
                name = departmentName,
            };

            return _dbConnection.QuerySingle<int>(query, queryArguments);
        }

        public int UpdateDepartmentName(UpdateDepartmentNameRequest request)
        {
            string query = "UPDATE departments SET department_name = @name WHERE department_id = @id";
            var queryArguments = new
            {
                name = request.DepartmentName,
                id = request.DepartmentId
            };

            return _dbConnection.Execute(query, queryArguments);
        }

        public int AddDepartmentLectureRelationship(int departmentId, int lectureId)
        {
            string query = "INSERT INTO department_lecture (department_id, lecture_id) VALUES (@departmentId, @lectureId)";
            var queryArguments = new
            {
                departmentId,
                lectureId
            };

            return _dbConnection.Execute(query, queryArguments);
        }

        public int DeleteDepartmentLectureRelationship(int departmentId, int lectureId)
        {
            string query = "DELETE FROM department_lecture WHERE lecture_id = @lecture_id AND department_id = @departmentId ";
            var queryArguments = new
            {
                departmentId,
                lectureId
            };

            return _dbConnection.Execute(query, queryArguments);
        }

    }
}
