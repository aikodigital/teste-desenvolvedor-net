using Microsoft.EntityFrameworkCore;
using OlhoVivo.Core.Domain.Entities;
using OlhoVivo.Core.Domain.Interfaces;
using OlhoVivo.Infra.Data.Context;

namespace OlhoVivo.Infra.Data.Repositories;

public class StopRepository : IStopRepository
{
    #region Properties
    ApplicationDbContext _stopContext;
    #endregion

    #region Constructor
    public StopRepository(ApplicationDbContext context)
    {
        _stopContext = context;
    }
    #endregion

    #region Methods
    public async Task<IEnumerable<Stop>> GetAll()
    {
        return await _stopContext.Stops.ToListAsync();
    }

    public async Task<Stop> GetById(long id)
    {
        return await _stopContext.Stops.FindAsync(id);
        // return await _stopContext.Stops.Include(i => i.Line).SingleOrDefaultAsync(s => s.Id == id);
    }
    public async Task<Stop> Create(Stop stop)
    {
        _stopContext.Add(stop);
        await _stopContext.SaveChangesAsync();

        return stop;
    }

    public async Task<Stop> Delete(Stop stop)
    {
        _stopContext.Remove(stop);
        await _stopContext.SaveChangesAsync();

        return stop;
    }

    public async Task<Stop> Update(Stop stop)
    {
        _stopContext.Update(stop);
        await _stopContext.SaveChangesAsync();

        return stop;
    }

    public async Task<IEnumerable<Stop>> GetStopsByLine(long lineId)
    {
        var stopsByLine = await _stopContext.Stops.Where(i => i.LineId == lineId).ToListAsync();
        return stopsByLine;
    }
    #endregion
}
