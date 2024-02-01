using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Application.UseCase.Linha.GetLine;
using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Useful;
using AutoMapper;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Parada.GetStop;

/// <summary>
/// Handler responsável por listar uma ou mais paradas castradas e ativas.
/// </summary>
public class GetStopQueryHandler : IRequestHandler<GetStopQuery, Result<IEnumerable<StopModel>>>
{
    private readonly IMapper _mapper;
    private readonly IStopRepository _stopRepository;

    public GetStopQueryHandler(IMapper mapper, IStopRepository stopRepository)
    {
        _mapper = mapper;
        _stopRepository = stopRepository;
    }

    public async Task<Result<IEnumerable<StopModel>>> Handle(GetStopQuery query, CancellationToken cancellationToken)
    {
        var stop = _mapper.Map<IEnumerable<StopModel>>
            (await _stopRepository.ListAsync(query.Id));

        return new()
        {
            Retorno = stop,
            Sucesso = stop.Any()
        };
    }
}