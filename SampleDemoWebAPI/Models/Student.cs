namespace SampleDemoWebAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public ICollection<StudentSubject> StudentSubjects { get; set; }
        public ICollection<StudentTeacher> StudentTeachers { get; set; }

    }
}
