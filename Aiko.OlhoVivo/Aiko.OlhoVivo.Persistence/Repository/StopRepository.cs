using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Dto;
using Aiko.OlhoVivo.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Aiko.OlhoVivo.Persistence.Repository;

public class StopRepository : BaseRepository<Stop>, IStopRepository
{
    private readonly AikoOlhoVivoContext _context;

    public StopRepository(AikoOlhoVivoContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Stop>> ListAsync(long? id)
    {
        var query = _context.Stop.AsQueryable();

        if (id > 0)
        {
            query = query.Where(x => x.Id == id);
        }

        return await query.AsNoTracking().ToListAsync();
    }
}
