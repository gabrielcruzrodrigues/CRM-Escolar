using CRM_Escolar.Data;
using CRM_Escolar.Domains;
using CRM_Escolar.Repository.Interfaces;
using CRM_Escolar.ViewModels;
using Microsoft.EntityFrameworkCore;
using CRM_Escolar.Extensions;

namespace CRM_Escolar.Repository
{
    public class ResponsibleRepository : IResponsibleRepository
    {
        private readonly MyAppContext _context;
        private readonly ILogger<ResponsibleRepository> _logger;

        public ResponsibleRepository(MyAppContext context, ILogger<ResponsibleRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Responsible> Create(CreateResponsibleViewModel request)
        {
            if (request is null)
            {
                throw new HttpResponseException(400, "The body request must not be null");
            }

            try
            {
                Responsible responsible = request.CreateResponsible();

                await _context.Responsibles.AddAsync(responsible);
                await _context.SaveChangesAsync();
                return responsible;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro tryning craete responsible, ex: {ex.Message}");
                throw new HttpResponseException(400, "Un error occurred when tryning create a responsible");
            }
        }

        public async Task<IEnumerable<Responsible>> GetAll()
        {
            return await _context.Responsibles
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Responsible> GetById(int responsibleId)
        {
            if (responsibleId <= 0)
            {
                throw new HttpResponseException(400, "The id must be bigger that zero!");
            }

            var responsible = await _context.Responsibles
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == responsibleId);

            if (responsible is null)
            {
                throw new HttpResponseException(404, $"The responsible with ID {responsibleId} not found!");
            }

            return responsible;
        }
    }
}
