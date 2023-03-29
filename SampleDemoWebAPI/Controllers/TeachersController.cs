using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleDemoWebAPI.DbContexts;
using SampleDemoWebAPI.Dto;
using SampleDemoWebAPI.Interfaces;
using SampleDemoWebAPI.Models;
using SampleDemoWebAPI.Repositories;

namespace SampleDemoWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeachersController:ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeachersController(ITeacherRepository teacherRepository ,IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }
        public IActionResult GetAllTeachers()
        {
            var teachers = _mapper.Map<List<TeacherDto>>(_teacherRepository.GetAllTeachers().ToList());
            if(ModelState.IsValid)
            {
                return Ok(teachers);
            }
            return BadRequest(ModelState);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetTeacherById(int id) {
            var teacher = _teacherRepository.GetTeacherById(id);
            if(ModelState.IsValid) return Ok(teacher);
            return BadRequest(ModelState);
        }
        [HttpGet("{name}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetTeacherByName(string name)
        {
            var teacher = _teacherRepository.GetTeacherByName(name);
            if (ModelState.IsValid) return Ok(teacher);
            return BadRequest(ModelState);
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CreateTeacher([FromBody] TeacherDto teacherDto)
        {
            if (teacherDto == null) return BadRequest(ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdTeacher = _mapper.Map<Teacher>(teacherDto);
            if (!_teacherRepository.CreateTeacher(createdTeacher))
            {
                ModelState.AddModelError("", "Smth went wrong while creating");
                return BadRequest(ModelState);
            }
            return Ok("Successfully created");
        }
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateTeacher(int id, [FromBody] TeacherDto teacherDto)
        {
            if (teacherDto == null) return BadRequest(ModelState);
            var teacher = _teacherRepository.GetTeacherById(id);
            if (teacher == null) return NotFound();
            var updatedTeacher= _mapper.Map<Teacher>(teacherDto);
            if (_teacherRepository.UpdateTeacher(updatedTeacher))
            {
                return Ok("Successfully updated");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteTeacher(int id)
        {
            var teacher = _teacherRepository.GetTeacherById(id);
            if (teacher == null) return NotFound();

            if (_teacherRepository.DeleteTeacher(teacher))
            {
                return Ok("Successfully deleted");
            }
            return BadRequest(ModelState);
        }
    }
}
