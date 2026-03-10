namespace UniversityCrud.Business.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
