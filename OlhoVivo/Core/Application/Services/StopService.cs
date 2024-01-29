using AutoMapper;
using OlhoVivo.Core.Application.DTOs;
using OlhoVivo.Core.Application.Interfaces;
using OlhoVivo.Core.Domain.Entities;
using OlhoVivo.Core.Domain.Interfaces;

namespace OlhoVivo.Core.Application.Services;

public class StopService : IStopService
{
    #region Properties
    private IStopRepository _stopRepository;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor
    public StopService(IStopRepository stopRepository, IMapper mapper)
    {
        _stopRepository = stopRepository;
        _mapper = mapper;
    }
    #endregion

    #region Methods
    public async Task<IEnumerable<StopDTO>> GetAll()
    {
        var stops = await _stopRepository.GetAll();
        var stopsDTO = _mapper.Map<IEnumerable<StopDTO>>(stops);

        return stopsDTO;
    }

    public async Task<StopDTO> GetById(long id)
    {
        var stop = await _stopRepository.GetById(id);
        var stopDTO = _mapper.Map<StopDTO>(stop);

        return stopDTO;
    }

    public async Task<IEnumerable<StopDTO>> GetStopsByLine(long lineId)
    {
        var stops = await _stopRepository.GetStopsByLine(lineId);
        var stopsDTO = _mapper.Map<IEnumerable<StopDTO>>(stops);

        return stopsDTO;
    }

    public async Task Create(StopDTO stopDTO)
    {
        var stop = _mapper.Map<Stop>(stopDTO);
        await _stopRepository.Create(stop);

        stopDTO.Id = stop.Id;        
    }

    public async Task Delete(long id)
    {
        var stop = _stopRepository.GetById(id).Result;
        await _stopRepository.Delete(stop);
    }

    public async Task Update(StopDTO stopDTO)
    {
        var stop = _mapper.Map<Stop>(stopDTO);
        await _stopRepository.Update(stop);
    }
    #endregion
}
