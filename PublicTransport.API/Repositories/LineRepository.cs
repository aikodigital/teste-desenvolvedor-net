using Microsoft.EntityFrameworkCore;
using PublicTransport.API.Entities;
using PublicTransport.API.Persistence;
using PublicTransport.API.Repositories.Interface;

namespace PublicTransport.API.Repositories;

public class LineRepository : ILineRepository
{
    private readonly PublicTransportDbContext _context;

    public LineRepository(PublicTransportDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Line>> GetAllAsync()
    {
        return await _context.Lines.ToListAsync();
    }

    public async Task<Line> GetByIdAsync(long id)
    {
        return await _context.Lines.FindAsync(id);
    }

    public async Task<Line> PostAsync(Line line)
    {
        _context.Lines.Add(line);
        await _context.SaveChangesAsync();
        return line;
    }

    public async Task<Line> UpdateAsync(Line line)
    {
        _context.Entry(line).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return line;
    }

    public async Task DeleteAsync(long id)
    {
        var line = await _context.Lines.FindAsync(id);
        _context.Lines.Remove(line);
        await _context.SaveChangesAsync();
    }

}
