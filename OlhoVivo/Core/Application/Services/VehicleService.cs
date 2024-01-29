using AutoMapper;
using OlhoVivo.Core.Application.DTOs;
using OlhoVivo.Core.Application.Interfaces;
using OlhoVivo.Core.Domain.Entities;
using OlhoVivo.Core.Domain.Interfaces;

namespace OlhoVivo.Core.Application.Services;

public class VehicleService : IVehicleService
{
    #region Properties
    private IVehicleRepository _vehicleRepository;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor
    public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)
    {
        _vehicleRepository = vehicleRepository;
        _mapper = mapper;
    }
    #endregion

    #region Methods
    public async Task<IEnumerable<VehicleDTO>> GetAll()
    {
        var vehicles = await _vehicleRepository.GetAll();
        var vehiclesDTO = _mapper.Map<IEnumerable<VehicleDTO>>(vehicles);

        return vehiclesDTO;
    }

    public async Task<IEnumerable<VehicleDTO>> GetVehiclesByLine(long lineId)
    {
        var vehicles = await _vehicleRepository.GetVehiclesByLine(lineId);
        var vehiclesDTO = _mapper.Map<IEnumerable<VehicleDTO>>(vehicles);

        return vehiclesDTO;
    }

    public async Task<VehicleDTO> GetById(long id)
    {
        var vehicle = await _vehicleRepository.GetById(id);
        var vehicleDTO = _mapper.Map<VehicleDTO>(vehicle);

        return vehicleDTO;
    }

    public async Task Create(VehicleDTO vehicleDTO)
    {
        var vehicle = _mapper.Map<Vehicle>(vehicleDTO);
        await _vehicleRepository.Create(vehicle);

        vehicleDTO.Id = vehicle.Id;
    }

    public async Task Update(VehicleDTO vehicleDTO)
    {
        var vehicle = _mapper.Map<Vehicle>(vehicleDTO);
        await _vehicleRepository.Update(vehicle);
    }

    public async Task Delete(long id)
    {
        var vehicle = _vehicleRepository.GetById(id).Result;
        await _vehicleRepository.Delete(vehicle);
    }
    #endregion
}
