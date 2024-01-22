namespace ApiTransporte.Core.Repositories
{
    public interface ICrudRepository<Model, Id>
    {
        bool ExistsById(Id id);
        ICollection<Model> FindAll();
        Model Create(Model model);
        Model? FindById(Id id);
        Model Update(Model model);
        void DeleteById(Id id);
    }
}
