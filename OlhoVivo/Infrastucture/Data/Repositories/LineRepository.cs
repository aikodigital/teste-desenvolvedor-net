using Microsoft.EntityFrameworkCore;
using OlhoVivo.Core.Domain.Entities;
using OlhoVivo.Core.Domain.Interfaces;
using OlhoVivo.Infra.Data.Context;

namespace OlhoVivo.Infra.Data.Repositories;

public class LineRepository : ILineRepository
{
    #region Properties
    ApplicationDbContext _lineContext;
    #endregion

    #region Constructor
    public LineRepository(ApplicationDbContext context)
    {
        _lineContext = context;
    }
    #endregion

    #region Methods
    public async Task<IEnumerable<Line>> GetAll()
    {
        return await _lineContext.Lines.ToListAsync();
    }

    public async Task<Line> GetById(long id)
    {
        return await _lineContext.Lines.FindAsync(id);
    }
    public async Task<Line> Create(Line line)
    {
        _lineContext.Add(line);
        await _lineContext.SaveChangesAsync();

        return line;
    }

    public async Task<Line> Delete(Line line)
    {
        _lineContext.Remove(line);
        await _lineContext.SaveChangesAsync();

        return line;
    }

    public async Task<Line> Update(Line line)
    {
        _lineContext.Update(line);
        await _lineContext.SaveChangesAsync();

        return line;
    }
    #endregion
}
