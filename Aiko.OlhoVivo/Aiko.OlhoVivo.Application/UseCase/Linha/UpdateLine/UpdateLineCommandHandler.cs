using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Dto;
using Aiko.OlhoVivo.Infrastructure.Useful;
using AutoMapper;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Linha.UpdateLine;

/// <summary>
/// Handler responsável por atualizar uma linha.
/// </summary>
public class UpdateLineCommandHandler : IRequestHandler<UpdateLineCommand, Result<LineModel>>
{
    private readonly IMapper _mapper;
    private readonly ILineRepository _lineRepository;

    public UpdateLineCommandHandler(IMapper mapper, ILineRepository lineRepository)
    {
        _mapper = mapper;
        _lineRepository = lineRepository;
    }

    public async Task<Result<LineModel>> Handle(UpdateLineCommand command, CancellationToken cancellationToken)
    {
        var line = _mapper.Map<Line>(command);
        
        var result = await _lineRepository.UpdateAsync(line);

        return new()
        {
            Retorno = _mapper.Map<LineModel>(line),
            Sucesso = result
        };
    }
}