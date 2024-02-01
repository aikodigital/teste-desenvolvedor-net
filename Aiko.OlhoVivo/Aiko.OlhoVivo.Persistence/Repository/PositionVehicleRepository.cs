using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Dto;
using Aiko.OlhoVivo.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Aiko.OlhoVivo.Persistence.Repository;

public class PositionVehicleRepository : BaseRepository<VehiclePosition>, IPositionVehicleRepository
{
    private readonly AikoOlhoVivoContext _context;

    public PositionVehicleRepository(AikoOlhoVivoContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<VehiclePosition>> ListAsync(long? id)
    {
        var query = _context.VehiclePosition.AsQueryable();

        if (id > 0)
        {
            query = query.Where(x => x.Id == id);
        }

        return await query.AsNoTracking().ToListAsync();
    }
}