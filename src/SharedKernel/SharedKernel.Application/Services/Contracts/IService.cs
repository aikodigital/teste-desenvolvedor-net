using SharedKernel.Infrastructure.Entities;
using SharedKernel.Infrastructure.Pagination;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SharedKernel.Application.Services.Contracts
{
    public interface IService<TEntity> where TEntity : EntityBase
    {

        Task<TEntity> Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);

        IQueryable<TEntity> QueryableFor(Expression<Func<TEntity, bool>> criteria = null, bool @readonly = false, params Expression<Func<TEntity, object>>[] includes);

        IQueryable<TEntity> Queryable();

        Task<PagedResult<TEntity>> PagedResult(int page, int pageSize, IList<TEntity> entity);
    }
}
