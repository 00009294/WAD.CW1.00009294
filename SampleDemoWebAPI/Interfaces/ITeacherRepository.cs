using SampleDemoWebAPI.Models;

namespace SampleDemoWebAPI.Interfaces
{
    public interface ITeacherRepository
    {
        ICollection<Teacher> GetAllTeachers();
        Teacher GetTeacherById(int id);
        Teacher GetTeacherByName(string name);
        bool CreateTeacher(Teacher teacher);
        bool UpdateTeacher(Teacher teacher);
        bool DeleteTeacher(Teacher teacher);
        bool IsExist(int id);
        bool Save();
    }
}
