namespace SharedKernel.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}
