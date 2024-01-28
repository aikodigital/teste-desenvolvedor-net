using AutoMapper;
using OlhoVivo.Core.Application.DTOs;
using OlhoVivo.Core.Application.Interfaces;
using OlhoVivo.Core.Domain.Entities;
using OlhoVivo.Core.Domain.Interfaces;

namespace OlhoVivo.Core.Application.Services;

public class VehiclePositionService : IVehiclePositionService
{
    #region Properties
    private IVehiclePositionRepository _vehiclePositionRepository;
    private readonly IMapper _mapper;
    #endregion

    #region Contructor
    public VehiclePositionService(IVehiclePositionRepository vehiclePositionRepository, IMapper mapper)
    {
        _vehiclePositionRepository = vehiclePositionRepository;
        _mapper = mapper;
    }
    #endregion

    #region Methods
    public async Task<IEnumerable<VehiclePositionDTO>> GetAll()
    {
        var vehiclesPosition = await _vehiclePositionRepository.GetAll();
        var vehiclesPositionDTO = _mapper.Map<IEnumerable<VehiclePositionDTO>>(vehiclesPosition);

        return vehiclesPositionDTO;
    }

    public async Task<VehiclePositionDTO> GetById(long id)
    {
        var vehiclePosition = await _vehiclePositionRepository.GetById(id);
        var vehiclePositionDTO = _mapper.Map<VehiclePositionDTO>(vehiclePosition);

        return vehiclePositionDTO;
    }
    public async Task Create(VehiclePositionDTO vehiclePositionDTO)
    {
        var vehiclePosition = _mapper.Map<VehiclePosition>(vehiclePositionDTO);
        await _vehiclePositionRepository.Create(vehiclePosition);

        vehiclePositionDTO.Id = vehiclePosition.Id;
    }

    public async Task Update(VehiclePositionDTO vehiclePositionDTO)
    {
        var vehiclePosition = _mapper.Map<VehiclePosition>(vehiclePositionDTO);
        await _vehiclePositionRepository.Update(vehiclePosition);
    }
    public async Task Delete(long id)
    {
        var vehiclePosition = _vehiclePositionRepository.GetById(id).Result;
        await _vehiclePositionRepository.Delete(vehiclePosition);
    }
    #endregion 
}