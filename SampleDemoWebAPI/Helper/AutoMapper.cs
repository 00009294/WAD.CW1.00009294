using AutoMapper;
using SampleDemoWebAPI.Dto;
using SampleDemoWebAPI.Models;

namespace SampleDemoWebAPI.Helper
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Subject, SubjectDto>();
            CreateMap<SubjectDto, Subject>();
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherDto, Teacher>();
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
        }
    }
}
