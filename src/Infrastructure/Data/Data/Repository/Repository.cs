using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Infrastructure.DataContext;
using SharedKernel.Infrastructure.Entities;
using SharedKernel.Infrastructure.Pagination;
using SharedKernel.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected IDataContext _context;
        private IDataContext context;
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly IMapper _mapper;

        public Repository(IDataContext context, IMapper _mapper)
        {
            this._context = context;

            var dbContext = context as DbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<TEntity> Queryable()
        {
            return _dbSet;
        }

        public IQueryable<TEntity> QueryableFor(Expression<Func<TEntity, bool>> criteria = null, bool @readonly = false, params Expression<Func<TEntity, object>>[] includes)
        {
            if (criteria == null)
            {
                if (includes == null)
                {
                    return _dbSet.Where(criteria);
                }

                var queryAll = _dbSet.AsQueryable();

                foreach (var include in includes)
                {
                    queryAll.Include(include);
                }

                return @readonly ? queryAll.AsNoTracking() : queryAll;
            }
            var queryWhere = _dbSet.Where(criteria);

            if (includes == null)
            {
                return queryWhere;
            }

            foreach (var include in includes)
            {
                queryWhere = queryWhere.Include(include);
            }

            return queryWhere;
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

    }
}
