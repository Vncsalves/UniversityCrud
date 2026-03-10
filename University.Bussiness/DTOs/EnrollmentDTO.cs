namespace UniversityCrud.Business.DTOs
{
    public class EnrollmentCreateDTO
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }
    }

    public class EnrollmentDTO
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string CourseName { get; set; }
    }


}