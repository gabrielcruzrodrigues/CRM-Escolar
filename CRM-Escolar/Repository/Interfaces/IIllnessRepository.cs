using CRM_Escolar.Domains;
using CRM_Escolar.ViewModels;

namespace CRM_Escolar.Repository.Interfaces
{
    public interface IIllnessRepository
    {
        Task<IEnumerable<Illness>> GetAll();
        Task<Illness> GetById(int illnessId);
        Task<Illness> Create(CreateIllnessViewModel createIllnessViewModel);
    }
}
