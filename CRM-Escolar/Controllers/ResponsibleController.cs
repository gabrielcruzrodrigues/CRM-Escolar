using CRM_Escolar.Domains;
using CRM_Escolar.Repository.Interfaces;
using CRM_Escolar.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Escolar.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResponsibleController : ControllerBase
    {
        private readonly IResponsibleRepository _repository;
        
        public ResponsibleController(IResponsibleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Responsible>>> GetAll()
        {
            var response = await _repository.GetAll();
            return Ok(response);
        }

        [HttpGet("{responsibleId}")]
        public async Task<ActionResult<Responsible>> GetById(int responsibleId)
        {
            var response = await _repository.GetById(responsibleId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateResponsibleViewModel request)
        { 
            var responsible = await _repository.Create(request);
            return StatusCode(201, responsible);
        }
    }
}
