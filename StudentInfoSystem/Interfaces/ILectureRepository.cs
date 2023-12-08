using StudentInfoSystem.Models.Entities;

namespace StudentInfoSystem.Interfaces
{
    public interface ILectureRepository
    {
        List<Lecture> GetLectures();

        int InsertLecture(string name);

        List<Lecture> GetLecturesByDepartmentId(int departmentId);

        List<Lecture> GetLecturesByStudentId(int studentId);

        void DeleteLecturesByStudentId(int id);
    }
}
