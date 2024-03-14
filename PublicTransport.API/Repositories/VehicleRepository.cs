using Microsoft.EntityFrameworkCore;
using PublicTransport.API.Entities;
using PublicTransport.API.Persistence;
using PublicTransport.API.Repositories.Interface;

namespace PublicTransport.API.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly PublicTransportDbContext _context;

        public VehicleRepository(PublicTransportDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> GetByIdAsync(long id)
        {
            return await _context.Vehicles.FindAsync(id);
        }

        public async Task CreateAsync(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vehicle vehicle)
        {
            _context.Entry(vehicle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
            }
        }
    }
}
