using CRM_Escolar.Data;
using CRM_Escolar.Domains;
using CRM_Escolar.ViewModels;
using CRM_Escolar.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CRM_Escolar.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly MyAppContext _context;
        private readonly ILogger<SchoolRepository> _logger;

        public SchoolRepository(MyAppContext context, ILogger<SchoolRepository> logger) 
        {
            _context = context;
            _logger = logger;
        }

        public async Task<School> Create(CreateSchoolViewModel request)
        {
            School school = request.createSchool();
            try
            {
                await _context.Schools.AddAsync(school);
                await _context.SaveChangesAsync();
                return school;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Aconteceu um erro ao tentar criar uma nova escola! - err: {ex.Message}");
                throw new HttpResponseException(400, "Aconteceu um erro ao tentar criar uma nova escola");
            }
        }

        public async Task<IEnumerable<School>> GetAll()
        {
            return await _context.Schools
                .AsNoTracking()
                .ToListAsync();
        }
        
        public async Task<School> GetById(int schoolId)
        {
            var school = await _context.Schools
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id.Equals(schoolId));

            if (school is null)
            {
                throw new HttpResponseException(404, $"O estudante com o ID {schoolId} não foi encontrado!");
            }

            return school;
        }
    }
}
