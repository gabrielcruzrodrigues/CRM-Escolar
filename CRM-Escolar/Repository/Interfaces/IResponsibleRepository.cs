using CRM_Escolar.Domains;
using CRM_Escolar.ViewModels;

namespace CRM_Escolar.Repository.Interfaces
{
    public interface IResponsibleRepository
    {
        Task<Responsible> Create(CreateResponsibleViewModel request);
        Task<IEnumerable<Responsible>> GetAll();
        Task<Responsible> GetById(int responsibleId);
    }
}
