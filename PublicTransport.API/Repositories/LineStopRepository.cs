using Microsoft.EntityFrameworkCore;
using PublicTransport.API.Entities;
using PublicTransport.API.Persistence;
using PublicTransport.API.Repositories.Interface;

namespace PublicTransport.API.Repositories;

public class LineStopRepository : ILineStopRepository
{
    private readonly PublicTransportDbContext _context;

    public LineStopRepository(PublicTransportDbContext context)
    {
        _context = context;
    }

    public async Task AddStopByLineAsync(long lineId, long stopId)
    {
        var lineEntity = await _context.Lines.Include(l => l.LineStops).FirstOrDefaultAsync(l => l.LineId == lineId);
        var stopEntity = await _context.Stops.FirstOrDefaultAsync(s => s.StopId == stopId);

        if (lineEntity == null)
            throw new KeyNotFoundException($"Linha com ID {lineId} não encontrada");

        if (stopEntity == null)
            throw new KeyNotFoundException($"Parada com ID {stopId} não encontrada");

        if (lineEntity.LineStops.Any(ls => ls.StopId == stopId))
            throw new InvalidOperationException("Parada já está associada à linha");

        var lineStop = new LineStop { LineId = lineId, StopId = stopId };
        _context.LineStops.Add(lineStop);

        int result = await _context.SaveChangesAsync();

        // Verifica se alguma entidade foi alterada
        if (result > 0)
        {
            Console.WriteLine("Alterações salvas com sucesso.");
        }
        else
        {
            Console.WriteLine("Nenhuma alteração foi feita no banco de dados.");
        }
    }

    public async Task<IEnumerable<Line>> GetLinesByStopIdAsync(long stopId)
    {
        return await _context.LineStops
            .Where(ls => ls.StopId == stopId)
            .Select(ls => ls.Line)
            .ToListAsync();
    }
}
