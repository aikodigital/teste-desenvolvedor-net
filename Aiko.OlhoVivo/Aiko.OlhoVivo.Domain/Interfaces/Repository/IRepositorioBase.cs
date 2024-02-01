namespace Aiko.OlhoVivo.Domain.Interfaces.Repository;

public interface IRepositorioBase<T> where T : class
{
    Task<bool> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
}