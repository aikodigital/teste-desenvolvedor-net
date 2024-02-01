using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Dto;
using Aiko.OlhoVivo.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.CodeDom;

namespace Aiko.OlhoVivo.Persistence.Repository;

public class LineStopRepository : BaseRepository<LineStop>, ILineStopRepository
{
    private readonly AikoOlhoVivoContext _context;

    public LineStopRepository(AikoOlhoVivoContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<LineStop>> ListAsyncLineStops(long id)
    {
        var query = _context.LineStop
            .Include(i => i.Line)
            .Where(x => x.StopId == id)
            .AsQueryable();

        return await query.AsNoTracking().ToListAsync();

    }
}