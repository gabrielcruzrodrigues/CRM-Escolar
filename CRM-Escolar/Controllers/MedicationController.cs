using CRM_Escolar.Domains;
using CRM_Escolar.Repository.Interfaces;
using CRM_Escolar.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Escolar.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly IMedicationRepository _repository;

        public MedicationController(IMedicationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medication>>> GetAll()
        {
            var response = await _repository.GetAll();
            return Ok(response);
        }

        [HttpGet("{medicationId}")]
        public async Task<ActionResult<Medication>> GetById(int medicationId)
        {
            var response = await _repository.GetById(medicationId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Medication>> Create(CreateMedicationViewModel request)
        {
            var response = await _repository.Create(request);
            return StatusCode(201, response);
        }
    }
}
