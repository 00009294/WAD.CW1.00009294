namespace SampleDemoWebAPI.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public ICollection<StudentTeacher> StudentTeachers { get; set; }
    }
}
