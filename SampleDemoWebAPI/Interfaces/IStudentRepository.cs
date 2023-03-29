using SampleDemoWebAPI.Models;

namespace SampleDemoWebAPI.Interfaces
{
    public interface IStudentRepository
    {
        ICollection<Student> GetAllStudents();
        Student GetStudentById(int id);
        Student GetStudentByName(string name);
        bool CreateStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(Student student);
        bool IsExist(int id);
        bool Save();
    }
}
