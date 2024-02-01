using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Application.UseCase.Parada.DeleteStop;
using Aiko.OlhoVivo.Application.UseCase.PositionVehicle.AddPositionVehicle;
using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Dto;
using Aiko.OlhoVivo.Infrastructure.Useful;
using Aiko.OlhoVivo.Persistence.Repository;
using AutoMapper;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.PositionVehicle.DeletePositionVehicle;

/// <summary>
/// Handler responsável por excluir uma posição veícular.
/// </summary>
public class DeletePositionVehicleCommandHandler : IRequestHandler<DeletePositionVehicleCommand, Result<VehiclePositionModel>>
{
    private readonly IMapper _mapper;
    private readonly IPositionVehicleRepository _positionVehicleRepository;

    public DeletePositionVehicleCommandHandler(IMapper mapper, IPositionVehicleRepository positionVehicleRepository)
    {
        _mapper = mapper;
        _positionVehicleRepository = positionVehicleRepository;
    }

    public async Task<Result<VehiclePositionModel>> Handle(DeletePositionVehicleCommand command, CancellationToken cancellationToken)
    {
        var erros = Array.Empty<string>();

        var vehiclePosition = (await _positionVehicleRepository.ListAsync(command.Id)).First();

        await _positionVehicleRepository.DeleteAsync(vehiclePosition);

        return new()
        {
            Erros = erros,
            Retorno = _mapper.Map<VehiclePositionModel>(vehiclePosition),
            Sucesso = !erros.Any()
        };
    }
}