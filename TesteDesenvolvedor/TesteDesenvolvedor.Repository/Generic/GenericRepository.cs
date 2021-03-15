using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Repository.Context;

namespace TesteDesenvolvedor.Repository.Generic
{
    public class GenericRepository : IRepository
    {

        protected readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;

        }

      
    }
}