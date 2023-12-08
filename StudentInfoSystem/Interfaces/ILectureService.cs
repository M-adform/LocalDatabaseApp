using StudentInfoSystem.Models.Entities;

namespace StudentInfoSystem.Interfaces
{
    public interface ILectureService
    {
        List<Lecture>? GetLectures();

        int? InsertLecture(string name, int departmentId);

        List<Lecture>? GetLecturesByDepartmentId(int departmentId);

        List<Lecture>? GetLecturesByStudentId(int studentId);
    }
}
