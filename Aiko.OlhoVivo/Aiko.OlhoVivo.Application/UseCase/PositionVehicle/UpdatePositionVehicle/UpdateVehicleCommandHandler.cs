using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Dto;
using Aiko.OlhoVivo.Infrastructure.Useful;
using AutoMapper;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.PositionVehicle.UpdatePositionVehicle;

/// <summary>
/// Handler responsável por atualizar uma parada veícular.
/// </summary>
public class UpdateVehicleCommandHandler : IRequestHandler<UpdatePositionVehicleCommand, Result<VehiclePositionModel>>
{
    private readonly IMapper _mapper;
    private readonly IPositionVehicleRepository _positionVehicleRepository ;

    public UpdateVehicleCommandHandler(IMapper mapper, IPositionVehicleRepository positionVehicleRepository)
    {
        _mapper = mapper;
        _positionVehicleRepository = positionVehicleRepository;
    }

    public async Task<Result<VehiclePositionModel>> Handle(UpdatePositionVehicleCommand command, CancellationToken cancellationToken)
    {
        var vehiclePosition = _mapper.Map<VehiclePosition>(command);

        var result = await _positionVehicleRepository.UpdateAsync(vehiclePosition);

        return new()
        {
            Retorno = _mapper.Map<VehiclePositionModel>(vehiclePosition),
            Sucesso = result
        };
    }
}