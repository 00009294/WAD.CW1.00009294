using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleDemoWebAPI.Dto;
using SampleDemoWebAPI.Interfaces;
using SampleDemoWebAPI.Models;

namespace SampleDemoWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetAllStudents()
        {
            var students = _mapper.Map<List<StudentDto>>(_studentRepository.GetAllStudents().ToList());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(students);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetStudentById(int id)
        {
            var student = _mapper.Map<StudentDto>(_studentRepository.GetStudentById(id));
            if (ModelState.IsValid)
            {
                return Ok(student);
            }
            ModelState.AddModelError("", "Not found");
            return BadRequest(ModelState);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetStudentByName(string name)
        {
            var student = _mapper.Map<StudentDto>(_studentRepository.GetStudentByName(name));
            if (ModelState.IsValid)
            {
                return Ok(student);
            }
            //ModelState.AddModelError("", "Not found");
            //return BadRequest(ModelState);
            return NotFound();
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CreateStudent([FromBody] StudentDto studentDto)
        {
            if (studentDto == null) return BadRequest(ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdStudent = _mapper.Map<Student>(studentDto);
            if (!_studentRepository.CreateStudent(createdStudent))
            {
                ModelState.AddModelError("", "Smth went wrong while creating");
                return BadRequest(ModelState);
            }
            return Ok("Successfully created");
        }
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateStudent(int id, [FromBody] StudentDto studentDto)
        {
            if (studentDto == null) return BadRequest(ModelState);
            var student = _studentRepository.GetStudentById(id);
            if (student == null) return NotFound();
            var updatedStudent = _mapper.Map<Student>(studentDto);
            if (_studentRepository.UpdateStudent(updatedStudent))
            {
                return Ok("Successfully updated");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentRepository.GetStudentById(id);
            if (student == null) return NotFound();

            if (_studentRepository.DeleteStudent(student))
            {
                return Ok("Successfully deleted");
            }
            return BadRequest(ModelState);
        }
    }
}
