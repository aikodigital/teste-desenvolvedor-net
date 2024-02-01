using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Dto;
using Aiko.OlhoVivo.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Aiko.OlhoVivo.Persistence.Repository;

public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
{
    private readonly AikoOlhoVivoContext _context;

    public VehicleRepository(AikoOlhoVivoContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Vehicle>> ListAsync(long? id)
    {
        var query = _context.Vehicle
            .Include(i => i.Line)
            .AsQueryable();

        if (id > 0)
        {
            query = query.Where(x => x.Id == id);
        }

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<Vehicle>> ListAsyncVehicleLine(long id)
    {
        return await _context.Vehicle
                    .Where(x => x.LineId == id)
                    .AsQueryable()
                    .AsNoTracking()
                    .ToListAsync();
    }
}