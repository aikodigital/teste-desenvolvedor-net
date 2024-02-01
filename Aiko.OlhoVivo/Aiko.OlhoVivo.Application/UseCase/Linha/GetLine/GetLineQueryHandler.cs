using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Useful;
using AutoMapper;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Linha.GetLine;

/// <summary>
/// Handler responsável por listar uma ou mais linhas castradas e ativas.
/// </summary>
public class GetLineQueryHandler : IRequestHandler<GetLineQuery, Result<IEnumerable<LineModel>>>
{
    private readonly IMapper _mapper;
    private readonly ILineRepository _lineRepository;

    public GetLineQueryHandler(IMapper mapper, ILineRepository lineRepository)
    {
        _mapper = mapper;
        _lineRepository = lineRepository;
    }

    public async Task<Result<IEnumerable<LineModel>>> Handle(GetLineQuery query, CancellationToken cancellationToken)
    {
        var line = _mapper.Map<IEnumerable<LineModel>>
            (await _lineRepository.ListAsync(query.Id));

        return new()
        {
            Retorno = line,
            Sucesso = line.Any()
        };
    }
}