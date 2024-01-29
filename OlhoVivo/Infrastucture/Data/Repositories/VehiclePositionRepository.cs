using Microsoft.EntityFrameworkCore;
using OlhoVivo.Core.Domain.Entities;
using OlhoVivo.Core.Domain.Interfaces;
using OlhoVivo.Infra.Data.Context;

namespace OlhoVivo.Infra.Data.Repositories;

public class VehiclePositionRepository : IVehiclePositionRepository
{
    #region Properties
    ApplicationDbContext _vehiclePositionContext;
    #endregion

    #region Constructor
    public VehiclePositionRepository(ApplicationDbContext context)
    {
        _vehiclePositionContext = context;
    }
    #endregion

    #region Methods
    public async Task<IEnumerable<VehiclePosition>> GetAll()
    {
        return await _vehiclePositionContext.VehiclesPositions.ToListAsync();
    }

    public async Task<VehiclePosition> GetById(long id)
    {
        return await _vehiclePositionContext.VehiclesPositions.FindAsync(id);
    }

    public async Task<VehiclePosition> Create(VehiclePosition vehiclePosition)
    {
        _vehiclePositionContext.Add(vehiclePosition);
        await _vehiclePositionContext.SaveChangesAsync();

        return vehiclePosition;
    }

    public async Task<VehiclePosition> Delete(VehiclePosition vehiclePosition)
    {
        _vehiclePositionContext.Remove(vehiclePosition);
        await _vehiclePositionContext.SaveChangesAsync();

        return vehiclePosition;
    }

    public async Task<VehiclePosition> Update(VehiclePosition vehiclePosition)
    {
        _vehiclePositionContext.Update(vehiclePosition);
        await _vehiclePositionContext.SaveChangesAsync();

        return vehiclePosition;
    }
    #endregion
}
