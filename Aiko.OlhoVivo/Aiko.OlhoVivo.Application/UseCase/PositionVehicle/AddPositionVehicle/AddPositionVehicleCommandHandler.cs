using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Dto;
using Aiko.OlhoVivo.Infrastructure.Useful;
using AutoMapper;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.PositionVehicle.AddPositionVehicle;

/// <summary>
/// Handler responsável por cadastrar uma nova posição veícular.
/// </summary>
public class AddPositionVehicleCommandHandler : IRequestHandler<AddPositionVehicleCommand, Result<VehiclePositionModel>>
{
    private readonly IMapper _mapper;
    private readonly IPositionVehicleRepository _positionVehicleRepository;

    public AddPositionVehicleCommandHandler(IMapper mapper, IPositionVehicleRepository positionVehicleRepository)
    {
        _mapper = mapper;
        _positionVehicleRepository = positionVehicleRepository;
    }

    public async Task<Result<VehiclePositionModel>> Handle(AddPositionVehicleCommand command, CancellationToken cancellationToken)
    {
        var erros = Array.Empty<string>();

        var vehiclePosition = _mapper.Map<VehiclePosition>(command);

        await _positionVehicleRepository.AddAsync(vehiclePosition);

        return new()
        {
            Erros = erros,
            Retorno = _mapper.Map<VehiclePositionModel>(vehiclePosition),
            Sucesso = !erros.Any()
        };
    }
}