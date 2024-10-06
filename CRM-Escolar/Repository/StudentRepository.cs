using CRM_Escolar.Data;
using CRM_Escolar.Domains;
using CRM_Escolar.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CRM_Escolar.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public readonly MyAppContext _context;
        public readonly ILogger<StudentRepository> _logger;

        public StudentRepository(MyAppContext context, ILogger<StudentRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Student> CreateAsync(Student student)
        {
            if (student is null)
            {
                throw new HttpResponseException(400, "O body para gerar o estudante não pode ser nulo!");
            }

            try
            {
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
                return student;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Um erro ocorreu ao tentar criar o estudante! err: {ex.Message}");
                throw new HttpResponseException(500, "Um erro ocorreu ao tentar criar o estudante!");
            }
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students
                .Include(s => s.School)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            if (id < 1)
            {
                throw new HttpResponseException(400, "O ID deve ser maior que 0");
            }

            var student = _context.Students
                .AsNoTracking()
                .FirstOrDefault(u => u.Id == id);

            if (student is null)
            {
                throw new HttpResponseException(404, $"O estudante com o Id: {id} não foi encontrado!");
            }

            return student;
        }

        public void Update(Student entity)
        {
            throw new NotImplementedException();
        }

        public async void Delete(int id)
        {
            Student student = await GetByIdAsync(id);

            try
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao tentar deletar o estudante! err: {ex.Message}");
                throw new HttpResponseException(500, "Ocorreu um erro ao tentar deletar o estudante!");
            }
        }
    }
}
