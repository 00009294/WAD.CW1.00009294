using Microsoft.EntityFrameworkCore;
using SampleDemoWebAPI.Models;
using System.Diagnostics;

namespace SampleDemoWebAPI.DbContexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; } = default!;
        public DbSet<Teacher> Teachers { get; set; } = default!;
        public DbSet<Subject> Subjects { get; set; } = default!;
        public DbSet<StudentTeacher> StudentTeachers { get; set; } = default!;
        public DbSet<StudentSubject> StudentSubject { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Subject)
                .WithMany(s => s.Teachers)
                .HasForeignKey(t => t.SubjectId);

            modelBuilder.Entity<StudentTeacher>()
                .HasKey(st => new { st.StudentId, st.TeacherId });
            modelBuilder.Entity<StudentTeacher>()
                .HasOne(st => st.Student)
                .WithMany(st => st.StudentTeachers)
                .HasForeignKey(st => st.TeacherId);
            modelBuilder.Entity<StudentTeacher>()
                .HasOne(st => st.Teacher)
                .WithMany(st => st.StudentTeachers)
                .HasForeignKey(st => st.StudentId);

            modelBuilder.Entity<StudentSubject>()
                .HasKey(st => new { st.StudentId, st.SubjectId });
            modelBuilder.Entity<StudentSubject>()
                .HasOne(st => st.Student)
                .WithMany(st => st.StudentSubjects)
                .HasForeignKey(st => st.SubjectId);
            modelBuilder.Entity<StudentSubject>()
               .HasOne(st => st.Subject)
               .WithMany(st => st.StudentSubjects)
               .HasForeignKey(st => st.StudentId);


        }
    }
}
