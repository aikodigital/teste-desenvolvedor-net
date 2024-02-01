using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Dto;
using Aiko.OlhoVivo.Infrastructure.Useful;
using AutoMapper;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Parada.AddStop;

/// <summary>
/// Handler responsável por cadastrar uma nova parada.
/// </summary>
public class AddStopCommandHandler : IRequestHandler<AddStopCommand, Result<StopModel>>
{
    private readonly IMapper _mapper;
    private readonly IStopRepository _stopRepository;

    public AddStopCommandHandler(IMapper mapper, IStopRepository stopRepository)
    {
        _mapper = mapper;
        _stopRepository = stopRepository;
    }

    public async Task<Result<StopModel>> Handle(AddStopCommand command, CancellationToken cancellationToken)
    {
        var erros = Array.Empty<string>();

        var stop = _mapper.Map<Stop>(command);

        await _stopRepository.AddAsync(stop);

        return new()
        {
            Erros = erros,
            Retorno = _mapper.Map<StopModel>(stop),
            Sucesso = !erros.Any()
        };
    }
}