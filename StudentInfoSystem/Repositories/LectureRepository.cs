using Dapper;
using StudentInfoSystem.Interfaces;
using StudentInfoSystem.Models.Entities;
using System.Data;

namespace StudentInfoSystem.Repositories
{
    public class LectureRepository : ILectureRepository
    {
        private readonly IDbConnection _dbConnection;
        public LectureRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<Lecture> GetLectures()
        {
            string query = "SELECT * FROM lectures";
            return _dbConnection.Query<Lecture>(query).ToList();
        }

        public int InsertLecture(string lectureName)
        {
            string query = "INSERT INTO lectures (lecture_Name) VALUES (@name) RETURNING lecture_id";
            var queryArguments = new
            {
                name = lectureName,
            };

            return _dbConnection.QuerySingle<int>(query, queryArguments);
        }

        public List<Lecture> GetLecturesByDepartmentId(int departmentId)
        {
            string query = "SELECT lectures.lecture_id, lectures.lecture_name FROM lectures " +
                "INNER JOIN department_lecture ON lectures.lecture_id = department_lecture.lecture_id " +
                "WHERE department_lecture.department_id = @departmentId";
            var queryArguments = new
            {
                departmentId,
            };

            return _dbConnection.Query<Lecture>(query, queryArguments).ToList();
        }

        public List<Lecture> GetLecturesByStudentId(int studentId)
        {
            string query = "SELECT lectures.lecture_id, lectures.lecture_name FROM lectures " +
                "INNER JOIN student_lecture ON lectures.lecture_id = student_lecture.lecture_id " +
                "WHERE student_lecture.student_id = @studentId";
            var queryArguments = new
            {
                studentId,
            };

            return _dbConnection.Query<Lecture>(query, queryArguments).ToList();
        }

        public void DeleteLecturesByStudentId(int id)
        {
            string query = "DELETE FROM student_lecture WHERE student_id = @id";
            var queryArguments = new
            {
                id,
            };

            _dbConnection.Execute(query, queryArguments);
        }

    }
}
