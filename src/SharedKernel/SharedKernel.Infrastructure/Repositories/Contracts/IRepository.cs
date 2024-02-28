using SharedKernel.Infrastructure.Entities;
using SharedKernel.Infrastructure.Pagination;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SharedKernel.Infrastructure.Repositories.Contracts
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);

        IQueryable<TEntity> Queryable();

        IQueryable<TEntity> QueryableFor(Expression<Func<TEntity, bool>> criteria = null, bool @readonly = false, params Expression<Func<TEntity, object>>[] includes);
    }
}
