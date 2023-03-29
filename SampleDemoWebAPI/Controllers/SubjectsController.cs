
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleDemoWebAPI.Dto;
using SampleDemoWebAPI.Interfaces;
using SampleDemoWebAPI.Models;

namespace SampleDemoWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectsController(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetAllSubjects()
        {
            var subjects = _mapper.Map<List<SubjectDto>>(_subjectRepository.GetAllSubjects());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(subjects);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetSubjectById(int id)
        {
            var subject = _mapper.Map<SubjectDto>(_subjectRepository.GetSubjectById(id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(subject);
        }
        [HttpGet("{name}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetSubjectByName(string name)
        {
            var subject = _mapper.Map<SubjectDto>(_subjectRepository.GetSubjectByName(name));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(subject);
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CreteSubject([FromBody] SubjectDto subjectDto)
        {
            if(subjectDto == null) return BadRequest(ModelState);
            if(!ModelState.IsValid) return BadRequest(ModelState);
            //var temp = _subjectRepository.IsExist(subjectDto.Id);
            //if (temp != null) return BadRequest(ModelState);
            var createdSubject = _mapper.Map<Subject>(subjectDto);
            if (_subjectRepository.CreateSubject(createdSubject))
            {
                return Ok("Successfully created");
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateSubject(int id, [FromBody] SubjectDto subjectDto)
        {
            if(subjectDto == null) return NotFound();
            var subject = _subjectRepository.GetAllSubjects().Where(s => s.Id == id).FirstOrDefault();
            if(subject == null) return NotFound();
            var updatedSubject = _mapper.Map<Subject>(subjectDto);
            if (!_subjectRepository.UpdateSubject(updatedSubject))
            {
                ModelState.AddModelError("", "Smth went wrong while updating");
                return BadRequest(ModelState);
            }
            return Ok("Successfully updated");
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteSubject(int id)
        {
            if(!_subjectRepository.IsExist(id)) return BadRequest(ModelState);
            var subject = _subjectRepository.GetSubjectById(id);
            var deletedSubject = _mapper.Map<Subject>(subject);
            if (!_subjectRepository.DeleteSubject(deletedSubject))
            {
                return BadRequest(ModelState);
            }
            return Ok("Successfully deleted");
        }

    }
}
