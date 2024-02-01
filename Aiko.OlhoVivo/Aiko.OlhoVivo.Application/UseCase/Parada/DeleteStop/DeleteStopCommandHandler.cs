using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Useful;
using AutoMapper;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Parada.DeleteStop;

/// <summary>
/// Handler responsável por excluir uma linha parada.
/// </summary>
public class DeleteStopCommandHandler : IRequestHandler<DeleteStopCommand, Result<StopModel>>
{
    private readonly IMapper _mapper;
    private readonly IStopRepository _stopRepository;

    public DeleteStopCommandHandler(IMapper mapper, IStopRepository stopRepository)
    {
        _mapper = mapper;
        _stopRepository = stopRepository;
    }

    public async Task<Result<StopModel>> Handle(DeleteStopCommand command, CancellationToken cancellationToken)
    {
        var erros = Array.Empty<string>();

        var stop = (await _stopRepository.ListAsync(command.Id)).First();

        await _stopRepository.DeleteAsync(stop);

        return new()
        {
            Erros = erros,
            Retorno = _mapper.Map<StopModel>(stop),
            Sucesso = !erros.Any()
        };
    }
}