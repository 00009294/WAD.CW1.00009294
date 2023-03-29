using SampleDemoWebAPI.DbContexts;
using SampleDemoWebAPI.Interfaces;
using SampleDemoWebAPI.Models;

namespace SampleDemoWebAPI.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _appDbContext;

        public SubjectRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public ICollection<Subject> GetAllSubjects()
        {
            var subjects = _appDbContext.Subjects.ToList();
            return subjects;
        }
        public Subject GetSubjectById(int id)
        {
            var subject = _appDbContext.Subjects.Where(s=>s.Id == id).FirstOrDefault();
            return subject;
        }

        public Subject GetSubjectByName(string name)
        {
            var subject = _appDbContext.Subjects.Where(s=>s.Name == name).FirstOrDefault();
            return subject;
        }
        public bool CreateSubject(Subject subject)
        {
           _appDbContext.Subjects.Add(subject);
            return Save();
        }

        public bool UpdateSubject(Subject subject)
        {
            _appDbContext.Update(subject);
            return Save();
        }
        public bool DeleteSubject(Subject subject)
        {
            _appDbContext.Remove(subject);
            return Save();
        }


        public bool IsExist(int id)
        {
            var subject = _appDbContext.Subjects.Where(s => s.Id == id).Any();
            return subject; 
        }

        public bool Save()
        {
            var saved = _appDbContext.SaveChanges();
            return saved > 0 ? true: false;
        }

    }
}
