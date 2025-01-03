using CRM_Escolar.Domains;
using CRM_Escolar.Repository;
using CRM_Escolar.Repository.Interfaces;
using CRM_Escolar.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Escolar.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly IStudentRepository _repository;
        public readonly IResponsibleRepository _responsibleRepository;

        public StudentController(IStudentRepository repository, IResponsibleRepository responsibleRepository)
        {
            _repository = repository;
            _responsibleRepository = responsibleRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateStudentViewModel studentViewModel)
        {
            if (studentViewModel is null)
            {
                return BadRequest("O body para criar o estudante não pode ser nulo!");
            }

            var responsibleVerify = await _responsibleRepository.GetById(studentViewModel.ResponsibleId);

            if (responsibleVerify is null)
            {
                return NotFound($"The responsible with id: {studentViewModel.ResponsibleId} not found!");
            }

            Student student = studentViewModel.CreateStudent();
            var userCreated = await _repository.CreateAsync(student);

            return StatusCode(201, new { response = userCreated });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudentsAsync()
        {
            var response = await _repository.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{userId:int}", Name ="GetStudent")]
        public async Task<ActionResult<Student>> GetByIdAsync(int userId)
        {
            return await _repository.GetByIdAsync(userId);
        }

        [HttpDelete("{userId:int}")]
        public async Task<IActionResult> Delete(int userId)
        {
            _repository.Delete(userId);
            return NoContent();
        }
    }
}
