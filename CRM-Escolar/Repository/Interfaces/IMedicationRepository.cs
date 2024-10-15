using CRM_Escolar.Domains;
using CRM_Escolar.ViewModels;

namespace CRM_Escolar.Repository.Interfaces
{
    public interface IMedicationRepository
    {
        Task<IEnumerable<Medication>> GetAll();
        Task<Medication> GetById(int medicationId);
        Task<Medication> Create(CreateMedicationViewModel medicationViewModel);
    }
}
