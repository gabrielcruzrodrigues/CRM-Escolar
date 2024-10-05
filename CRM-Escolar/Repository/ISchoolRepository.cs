using CRM_Escolar.Domains;
using CRM_Escolar.ViewModels;

namespace CRM_Escolar.Repository
{
    public interface ISchoolRepository
    {
        Task<School> Create(CreateSchoolViewModel request);
        Task<IEnumerable<School>> GetAll();
        Task<School> GetById(int schoolId);
    }
}
