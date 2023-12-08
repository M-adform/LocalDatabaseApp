namespace StudentInfoSystem.Models.RequestDTOs
{
    public class GetDepartmentRequest
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public int LectureId { get; set; }
    }
}
