namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    //Note : IGenericRepository = we have public repository that accepts a type parameter called T where T is a 
    //type of class
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
