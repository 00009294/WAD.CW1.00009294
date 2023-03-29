using SampleDemoWebAPI.DbContexts;
using SampleDemoWebAPI.Interfaces;
using SampleDemoWebAPI.Models;

namespace SampleDemoWebAPI.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _appDbContext;

        public TeacherRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public bool CreateTeacher(Teacher teacher)
        {
            _appDbContext.Add(teacher);
            return Save();
        }

        public bool DeleteTeacher(Teacher teacher)
        {
            _appDbContext.Remove(teacher);
            return Save();
        }

        public ICollection<Teacher> GetAllTeachers()
        {
            var teachers = _appDbContext.Teachers.ToList();
            return teachers;
        }

        public Teacher GetTeacherById(int id)
        {
            var teacher = _appDbContext.Teachers.Where(t=>t.Id== id).FirstOrDefault();
            return teacher;
        }

        public Teacher GetTeacherByName(string name)
        {
            var teacher = _appDbContext.Teachers.Where(t => t.Name == name).FirstOrDefault();
            return teacher;
        }

        public bool IsExist(int id)
        {
            var teacher = _appDbContext.Teachers.Where(t => t.Id == id).Any();
            return teacher;
        }

        public bool Save()
        {
            var saved = _appDbContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            _appDbContext.Update(teacher);
            return Save();
        }
    }
}
