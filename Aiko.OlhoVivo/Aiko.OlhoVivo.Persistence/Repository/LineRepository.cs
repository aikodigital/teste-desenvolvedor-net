using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Dto;
using Aiko.OlhoVivo.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace Aiko.OlhoVivo.Persistence.Repository;

public class LineRepository : BaseRepository<Line>, ILineRepository
{
    private readonly AikoOlhoVivoContext _context;

    public LineRepository(AikoOlhoVivoContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Line>> ListAsync(long? id)
    { 

        var query = _context.Line
            .Include(i => i.LineStop)
            .ThenInclude(i => i.Stop)
            .AsQueryable();

        if (id > 0)
        {
            query = query.Where(x => x.Id == id);
        }

        return await query.AsNoTracking().ToListAsync();
    }
}
