using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Dto;
using Aiko.OlhoVivo.Infrastructure.Useful;
using AutoMapper;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Linha.AddLine;

/// <summary>
/// Handler responsável por cadastrar uma nova linha.
/// </summary>
public class AddLineCommandHandler : IRequestHandler<AddLineCommand, Result<LineModel>>
{
    private readonly IMapper _mapper;
    private readonly ILineRepository _lineRepository;

    public AddLineCommandHandler(IMapper mapper, ILineRepository lineRepository)
    {
        _mapper = mapper;
        _lineRepository = lineRepository;
    }

    public async Task<Result<LineModel>> Handle(AddLineCommand command, CancellationToken cancellationToken)
    {
        var erros = Array.Empty<string>();

        var line = _mapper.Map<Line>(command);

        await _lineRepository.AddAsync(line);

        return new()
        {
            Erros = erros,
            Retorno = _mapper.Map<LineModel>(line),
            Sucesso = !erros.Any()
        };
    }
}