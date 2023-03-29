namespace SampleDemoWebAPI.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = String.Empty;
        public ICollection<StudentSubject> StudentSubjects { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
