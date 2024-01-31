using PublicTransportation.Domain.Entities;

namespace PublicTransportation.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        public void Commit();
        public IQueryable<TEntity> Queryable();
        public IQueryable<TEntity> AsNoTracking(IQueryable<TEntity> query);
        public TEntity GetById(long id);
        public IEnumerable<TEntity> GetAll();
        public void Create(TEntity entity);
        public void Create(IEnumerable<TEntity> entities);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        public int Count();

        public IQueryable<TEntity> ApplyIncludes(IQueryable<TEntity> query);
    }
}
