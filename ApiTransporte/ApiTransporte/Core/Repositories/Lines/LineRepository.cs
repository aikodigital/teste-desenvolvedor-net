using ApiTransporte.Core.Data.Contexts;
using ApiTransporte.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTransporte.Core.Repositories.Lines
{
    public class LineRepository : ILineRepository
    {
        private readonly TransporteContext _context;

        public LineRepository(TransporteContext context)
        {
            _context = context;
        }

        public Line Create(Line model)
        {
            _context.Lines.Add(model);
            _context.SaveChanges();
            return model;
        }

        public void DeleteById(long id)
        {
            var result = _context.Lines.Find(id);
            if (result != null)
            {
                _context.Lines.Remove(result);
                _context.SaveChanges();
            }
        }

        public bool ExistsById(long id)
        {
            return _context.Lines.Any(x => x.Id == id);
        }

        public ICollection<Line> FindAll()
        {
            return _context.Lines.AsNoTracking().ToList();
        }

        public Line? FindById(long id)
        {
            return _context.Lines.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public Line Update(Line model)
        {
            _context.Lines.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
