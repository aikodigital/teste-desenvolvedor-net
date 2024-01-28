using System.Xml.Serialization;
using AutoMapper;
using OlhoVivo.Core.Application.DTOs;
using OlhoVivo.Core.Application.Interfaces;
using OlhoVivo.Core.Domain.Entities;
using OlhoVivo.Core.Domain.Interfaces;

namespace OlhoVivo.Core.Application.Services;

public class LineService : ILineService
{
    #region Properties
    private ILineRepository _lineRepository;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor
    public LineService(ILineRepository lineRepository, IMapper mapper)
    {
        _lineRepository = lineRepository;
        _mapper = mapper;
    }
    #endregion

    #region Methods

    public async Task<IEnumerable<LineDTO>> GetAll()
    {
        var lines = await _lineRepository.GetAll();
        var linesDTO = _mapper.Map<IEnumerable<LineDTO>>(lines);

        return linesDTO;
    }

    public async Task<LineDTO> GetById(long id)
    {
        var line = await _lineRepository.GetById(id);
        var lineDTO = _mapper.Map<LineDTO>(line);

        return lineDTO;
    }

    public async Task Create(LineDTO lineDTO)
    {
        var line = _mapper.Map<Line>(lineDTO);
        await _lineRepository.Create(line);

        lineDTO.Id = line.Id;
    }

    public async Task Update(LineDTO lineDTO)
    {
        var line = _mapper.Map<Line>(lineDTO);
        await _lineRepository.Update(line);
    }

    public async Task Delete(long id)
    {
        var line = _lineRepository.GetById(id).Result;
        await _lineRepository.Delete(line);
    }
    #endregion
}
