namespace citasMedicasBackend2.Repositories
{
    public interface IRepository<T> where T : class //esta interfaz seria parecida a JPARepository
    {
        Task<IEnumerable<T>> GetAllAsync(); //el Task lo ponemos para indicar que son operaciones asincrónicas
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
