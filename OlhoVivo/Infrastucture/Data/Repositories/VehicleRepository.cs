using Microsoft.EntityFrameworkCore;
using OlhoVivo.Core.Domain.Entities;
using OlhoVivo.Core.Domain.Interfaces;
using OlhoVivo.Infra.Data.Context;

namespace OlhoVivo.Infra.Data.Repositories;

public class VehicleRepository : IVehicleRepository
{
    #region Properties
    ApplicationDbContext _vehicleContext;
    #endregion

    #region Constructor
    public VehicleRepository(ApplicationDbContext context)
    {
        _vehicleContext = context;
    }
    #endregion

    #region Methods
    public async Task<IEnumerable<Vehicle>> GetAll()
    {
        return await _vehicleContext.Vehicles.ToListAsync();
    }

    public async Task<Vehicle> GetById(long id)
    {
        return await _vehicleContext.Vehicles.FindAsync(id);
    }
    public async Task<Vehicle> Create(Vehicle vehicle)
    {
        _vehicleContext.Add(vehicle);
        await _vehicleContext.SaveChangesAsync();

        return vehicle;
    }

    public async Task<Vehicle> Delete(Vehicle vehicle)
    {
        _vehicleContext.Remove(vehicle);
        await _vehicleContext.SaveChangesAsync();

        return vehicle;
    }

    public async Task<Vehicle> Update(Vehicle vehicle)
    {
        _vehicleContext.Update(vehicle);
        await _vehicleContext.SaveChangesAsync();

        return vehicle;
    }

    public async Task<IEnumerable<Vehicle>> GetVehiclesByLine(long lineId)
    {
        var vehiclesByLine = await _vehicleContext.Vehicles.Where(i => i.LineId == lineId).ToListAsync();
        return vehiclesByLine;
    }
    #endregion
}
