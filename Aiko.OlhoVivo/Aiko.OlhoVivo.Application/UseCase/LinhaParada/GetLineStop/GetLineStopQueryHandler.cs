using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Application.UseCase.Linha.GetLine;
using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Useful;
using AutoMapper;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.LinhaParada.GetLineStop;

public class GetLineStopQueryHandler : IRequestHandler<GetLineStopQuery, Result<IEnumerable<LineModel>>>
{
    private readonly IMapper _mapper;
    private readonly ILineStopRepository _lineStopRepository;

    public GetLineStopQueryHandler(IMapper mapper, ILineStopRepository lineStopRepository)
    {
        _mapper = mapper;
        _lineStopRepository = lineStopRepository;
    }

    public async Task<Result<IEnumerable<LineModel>>> Handle(GetLineStopQuery query, CancellationToken cancellationToken)
    {
        var lineStop = await _lineStopRepository.ListAsyncLineStops(query.Id);
        var line = _mapper.Map<IEnumerable<LineModel>>(lineStop.Select(x => x.Line));

        return new()
        {
            Retorno = line,
            Sucesso = line.Any()
        };
    }
}