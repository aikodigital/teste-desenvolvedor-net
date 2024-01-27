using Microsoft.EntityFrameworkCore;
using PublicTransportation.Domain.Entities;
using PublicTransportation.Domain.Interfaces.Repositories;
using PublicTransportation.Infra.Context;
using System.Collections.Generic;
using System.Linq;

namespace PublicTransportation.Infra.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity 
    {
        private readonly ApiDbContext _context;
        protected readonly DbSet<TEntity> _db;

        public BaseRepository(ApiDbContext context)
        {
            _context = context;
            if (context != null)
                _db = context.Set<TEntity>();
        }

        public void Commit() => _context.SaveChanges();

        public IQueryable<TEntity> Queryable()
            => _db.AsQueryable();

        public virtual TEntity GetById(long id)
            => _db.Find(id);

        public virtual IEnumerable<TEntity> GetAll()
            => _db.AsNoTracking().ToList();

        public virtual void Create(TEntity entity)
            => _db.Add(entity);

        public virtual void Create(IEnumerable<TEntity> entities)
            => _db.AddRange(entities);

        public virtual void Update(TEntity entity)
            => _context.Entry(entity).State = EntityState.Modified;

        public virtual void Delete(TEntity entity)
            => _db.Remove(entity);

        public virtual int Count() => _db.Count();
    }
}
