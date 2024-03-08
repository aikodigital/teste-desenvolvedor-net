using PublicTransport.API.Entities;
using PublicTransport.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using PublicTransport.API.Persistence;

namespace PublicTransport.API.Repositories;

public class VehiclePositionRepository : IVehiclePositionRepository
{
    private readonly PublicTransportDbContext _context;

    public VehiclePositionRepository(PublicTransportDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<VehiclePosition>> GetAllAsync()
    {
        return await _context.VehiclePositions.ToListAsync();
    }

    public async Task<VehiclePosition> GetByIdAsync(long id)
    {
        return await _context.VehiclePositions.FindAsync(id);
    }

    public async Task CreateAsync(VehiclePosition vehiclePosition)
    {
        _context.VehiclePositions.Add(vehiclePosition);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(VehiclePosition vehiclePosition)
    {
        _context.Entry(vehiclePosition).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var vehiclePosition = await _context.VehiclePositions.FindAsync(id);
        if (vehiclePosition != null)
        {
            _context.VehiclePositions.Remove(vehiclePosition);
            await _context.SaveChangesAsync();
        }
    }
}
