using Microsoft.EntityFrameworkCore;
using PublicTransport.API.Entities;
using PublicTransport.API.Persistence;
using PublicTransport.API.Repositories.Interface;

namespace PublicTransport.API.Repositories;

public class StopRepository : IStopRepository
{
    private readonly PublicTransportDbContext _context;

    public StopRepository(PublicTransportDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Stop>> GetAllAsync()
    {
        return await _context.Stops.ToListAsync();
    }

    public async Task<Stop> GetByIdAsync(long id)
    {
        return await _context.Stops.FindAsync(id);
    }

    public async Task CreateAsync(Stop stop)
    {
        _context.Stops.Add(stop);
        await _context.SaveChangesAsync();
    }

    public async Task CreateWithLineAsync(Stop stop, long lineId)
    {
        _context.Stops.Add(stop);
        await _context.SaveChangesAsync();

        var lineStop = new LineStop { LineId = lineId, StopId = stop.StopId };
        _context.LineStops.Add(lineStop);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Stop stop)
    {
        _context.Entry(stop).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var stop = await _context.Stops.FindAsync(id);
        _context.Stops.Remove(stop);
        await _context.SaveChangesAsync();
    }
}
