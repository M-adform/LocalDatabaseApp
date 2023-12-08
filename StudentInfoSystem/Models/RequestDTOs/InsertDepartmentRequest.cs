namespace StudentInfoSystem.Models.RequestDTOs
{
    public class InsertDepartmentRequest
    {
        public string DepartmentName { get; set; }

        public List<string> StudentNames { get; set; }

        public List<string> LectureNames { get; set; }
    }
}
