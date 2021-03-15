using System.Collections.Generic;
using System.Threading.Tasks;

namespace TesteDesenvolvedor.Repository.Generic
{
    public interface IRepository
    {
        void Add<T>(T entity)  where T : class;
        void Update<T> (T entity) where T : class;
        void UpdateTeste<T> (T item, T entity) where T : class;
        void Delete<T> (T entity) where T : class;
        Task<bool> SaveChangesAsync();

    }
}