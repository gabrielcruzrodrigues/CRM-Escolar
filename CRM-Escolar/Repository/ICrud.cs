namespace CRM_Escolar.Repository
{
    public interface ICrud<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        void Update(T entity);
        void Delete(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
