using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Dto;
using Aiko.OlhoVivo.Infrastructure.Useful;
using AutoMapper;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Parada.UpdateStop;

/// <summary>
/// Handler responsável por atualizar uma parada.
/// </summary>
public class UpdateStopCommandHandler : IRequestHandler<UpdateStopCommand, Result<StopModel>>
{
    private readonly IMapper _mapper;
    private readonly IStopRepository _stopRepository;

    public UpdateStopCommandHandler(IMapper mapper, IStopRepository stopRepository)
    {
        _mapper = mapper;
        _stopRepository = stopRepository;
    }

    public async Task<Result<StopModel>> Handle(UpdateStopCommand command, CancellationToken cancellationToken)
    {
        var stop = _mapper.Map<Stop>(command);

        var result = await _stopRepository.UpdateAsync(stop);

        return new()
        {
            Retorno = _mapper.Map<StopModel>(stop),
            Sucesso = result
        };
    }
}