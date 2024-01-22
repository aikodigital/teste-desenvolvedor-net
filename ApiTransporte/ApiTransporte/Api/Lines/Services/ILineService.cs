using ApiTransporte.Core.Models;

namespace ApiTransporte.Api.Lines.Services
{
    public interface ILineService
    {
        ICollection<Line> FindAll();
        Line FindById(long id);
        Line Create(Line line);
        Line UpdateById(long id, Line line);
        void DeleteById(long id);
    }
}
