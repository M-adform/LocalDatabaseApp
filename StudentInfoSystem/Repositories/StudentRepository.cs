using Dapper;
using StudentInfoSystem.Interfaces;
using StudentInfoSystem.Models.Entities;
using StudentInfoSystem.Models.RequestDTOs;
using System.Data;

namespace StudentInfoSystem.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbConnection _dbConnection;

        public StudentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public int InsertStudent(string studentName, int dpartmentId)
        {
            string query = "INSERT INTO students (student_name, department_id) VALUES (@name, @department_id) RETURNING student_id";
            var queryArguments = new
            {
                name = studentName,
                department_id = dpartmentId
            };

            return _dbConnection.QuerySingle<int>(query, queryArguments);
        }

        public int AddStudentLectureRelationship(int studentId, int lectureId)
        {
            string query = "INSERT INTO student_lecture (student_id, lecture_id) VALUES (@studentId, @lectureId)";
            var queryArguments = new
            {
                studentId,
                lectureId
            };

            return _dbConnection.Execute(query, queryArguments);
        }

        public void UpdateStudentDepartment(UpdateStudentDepartmentRequest request)
        {
            string query = "UPDATE students SET department_id = @department_id WHERE student_id = @id";
            var queryArguments = new
            {
                id = request.Id,
                department_id = request.DepartmentId
            };

            _dbConnection.Execute(query, queryArguments);
        }

        public List<Student> GetStudentsByDepartmentId(int id)
        {
            string query = "SELECT * FROM students WHERE department_id = @id";
            var queryArguments = new
            {
                id,
            };

            return _dbConnection.Query<Student>(query, queryArguments).ToList();
        }

        public Student GetStudentByStudentId(int id)
        {
            string query = "SELECT * FROM students WHERE student_id = @id";
            var queryArguments = new
            {
                id,
            };

            return _dbConnection.QuerySingle<Student>(query, queryArguments);
        }
    }
}
