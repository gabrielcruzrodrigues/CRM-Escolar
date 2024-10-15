using CRM_Escolar.Data;
using CRM_Escolar.Domains;
using CRM_Escolar.Repository.Interfaces;
using CRM_Escolar.ViewModels;
using Microsoft.EntityFrameworkCore;
using CRM_Escolar.Extensions;

namespace CRM_Escolar.Repository
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly MyAppContext _context;
        private readonly ILogger<MedicationRepository> _logger;

        public MedicationRepository(MyAppContext context, ILogger<MedicationRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Medication> Create(CreateMedicationViewModel medicationViewModel)
        {
            Medication medication = medicationViewModel.CreateMedicationObj();

            if (medication is null)
            {
                throw new HttpResponseException(400, "Un error occurred when tryning create a new obj of type Medication");
            }

            try
            {
                await _context.Medications.AddAsync(medication);
                await _context.SaveChangesAsync();
                return medication;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Erro tryning create a new Medication! - err: {ex.Message}");
                throw new HttpResponseException(400, "Un erro occured when tryning create a new Medication");
            }
        }

        public async Task<IEnumerable<Medication>> GetAll()
        {
            return await _context.Medications
                    .AsNoTracking()
                    .Include(m => m.Student)
                    .ToListAsync();
        }

        public async Task<Medication> GetById(int medicationId)
        {
            var medication = await _context.Medications
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.Id.Equals(medicationId));

            if (medication is null)
            {
                throw new HttpResponseException(404, $"The medication with id: {medicationId} not found!");
            }

            return medication;
        }
    }
}
