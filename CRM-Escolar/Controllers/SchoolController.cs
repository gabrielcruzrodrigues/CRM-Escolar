using CRM_Escolar.Domains;
using CRM_Escolar.Repository;
using CRM_Escolar.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Escolar.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        [HttpPost]
        public async Task<ActionResult<School>> create(CreateSchoolViewModel request)
        {
            if (request is null)
            {
                return BadRequest(new { message = "O corpo da requisição não pode ser nulo!" });
            }

            var response = await _schoolRepository.Create(request);
            return Created("/school/{schoolId}", response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<School>>> GetAll()
        {
            var response = await _schoolRepository.GetAll();
            return Ok(response);
        }

        [HttpGet("{schoolId}")]
        public async Task<ActionResult<School>> GetById(int schoolId)
        {
            if (schoolId <= 0)
            {
                return BadRequest(new { message = "O id da escola deve ser maior que 0!" });
            }

            var school = await _schoolRepository.GetById(schoolId);
            return Ok(school);
        }
    }
}
