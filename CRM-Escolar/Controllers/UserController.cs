﻿using CRM_Escolar.Domains;
using CRM_Escolar.Repository;
using CRM_Escolar.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Escolar.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly IStudentRepository _repository;

        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateStudentViewModel studentViewModel)
        {
            if (studentViewModel is null)
            {
                return BadRequest("O body para criar o estudante não pode ser nulo!");
            }

            Student student = studentViewModel.CreateStudent();
            var userCreated = await _repository.CreateAsync(student);

            return new CreatedAtRouteResult("GetStudent", new { id = userCreated.Id }, userCreated);
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _repository.GetAllAsync();
        }

        [HttpGet("{id:int}", Name ="GetStudent")]
        public async Task<ActionResult<Student>> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
