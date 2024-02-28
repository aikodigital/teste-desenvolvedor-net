using Data.Context;
using Microsoft.EntityFrameworkCore.Storage;
using SharedKernel.Infrastructure.DataContext;
using SharedKernel.Infrastructure.UnitOfWork;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected IDataContext _context;
        protected IDbContextTransaction _transaction;

        public UnitOfWork(AikoContext context)
        {
            _context = context;

        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

    }
}
