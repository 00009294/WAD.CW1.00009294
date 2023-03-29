using SampleDemoWebAPI.Models;

namespace SampleDemoWebAPI.Interfaces
{
    public interface ISubjectRepository
    {
        ICollection<Subject> GetAllSubjects();
        Subject GetSubjectById(int id);
        Subject GetSubjectByName(string name);
        bool CreateSubject (Subject subject);
        bool UpdateSubject (Subject subject);
        bool DeleteSubject (Subject subject);
        bool IsExist(int id);
        bool Save();
    }
}
