using SampleDemoWebAPI.DbContexts;
using SampleDemoWebAPI.Interfaces;
using SampleDemoWebAPI.Models;

namespace SampleDemoWebAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public ICollection<Student> GetAllStudents()
        {
            var students = _appDbContext.Students.ToList();
            return students;
        }
        public bool CreateStudent(Student student)
        {
            _appDbContext.Students.Add(student);
            return Save();
        }

        public Student GetStudentById(int id)
        {
            var student = _appDbContext.Students.Where(s=>s.Id == id).FirstOrDefault();
            return student;
        }

        public Student GetStudentByName(string name)
        {
            var student = _appDbContext.Students.Where(s=>s.Name== name).FirstOrDefault();
            return student;
        }

        public bool UpdateStudent(Student student)
        {
            _appDbContext.Update(student);
            return Save();
        }
        public bool DeleteStudent(Student student)
        {
            _appDbContext.Students.Remove(student);
            return Save();
        }

        public bool IsExist(int id)
        {
            var student = _appDbContext.Students.Where(s => s.Id == id).Any();
            return student;
        }

        public bool Save()
        {
            var saved = _appDbContext.SaveChanges();
            return saved > 0 ? true : false;
            
        }

    }
}
