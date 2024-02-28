using SharedKernel.Application.Services.Contracts;
using SharedKernel.Infrastructure.Entities;
using SharedKernel.Infrastructure.Pagination;
using SharedKernel.Infrastructure.Repositories.Contracts;
using SharedKernel.Infrastructure.UnitOfWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SharedKernel.Application.Services
{
    public class Service<TEntity, Repository> : IService<TEntity> where TEntity : EntityBase where Repository : IRepository<TEntity>
    {
        protected readonly Repository _repository;
        protected readonly IUnitOfWork _unitOfWork;

        public Service(
            Repository repository,
            IUnitOfWork unitOfWork
            )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _repository.Add(entity);
            _unitOfWork.SaveChanges();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
            _unitOfWork.SaveChanges();
        }

        public TEntity Update(TEntity entity)
        {
            _repository.Update(entity);
            _unitOfWork.SaveChanges();
            return entity;
        }

        public IQueryable<TEntity> Queryable()
        {
            return _repository.Queryable();
        }

        public IQueryable<TEntity> QueryableFor(Expression<Func<TEntity, bool>> criteria = null, bool @readonly = false, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.QueryableFor();
        }

        public async Task<PagedResult<TEntity>> PagedResult(int page, int pageSize, IList<TEntity> entity)
        {
            return new PagedResult<TEntity>
            {
                Page = page,
                PageSize = pageSize,
                Items = entity.OrderBy(p => p.Id).Skip(pageSize * (page - 1)).Take(pageSize).ToList(),
                TotalItems = entity.Count()
            };
        }
    }
}
