using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_Escolar.Domains;
using CRM_Escolar.Repository;
using CRM_Escolar.Repository.Interfaces;
using CRM_Escolar.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Escolar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IllnessController : ControllerBase
    {
        private readonly IIllnessRepository _illnessRepository;
        private readonly IStudentRepository _studentRepository;

        public IllnessController(IIllnessRepository illnessRepository, IStudentRepository studentRepository)
        {
            _illnessRepository = illnessRepository;
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Illness>>> GetAll()
        {
            var response = await _illnessRepository.GetAll();
            return Ok(response);
        }

        [HttpGet("{illnessId}")]
        public async Task<ActionResult<Illness>> GetById(int illnessId)
        {
            var illness = await _illnessRepository.GetById(illnessId);
            return Ok(illness);
        }

        [HttpPost]
        public async Task<ActionResult<Illness>> Create(CreateIllnessViewModel request)
        {
            if (request is null)
            {
                return BadRequest("the body for create Illness not must be null");
            }

            await _studentRepository.GetByIdAsync(request.StudentId);
            var illness = await _illnessRepository.Create(request);
            return StatusCode(201, illness);
        }
    }
}