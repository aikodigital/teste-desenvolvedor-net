using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Application.UseCase.Parada.UpdateStop;
using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Dto;
using Aiko.OlhoVivo.Infrastructure.Useful;
using AutoMapper;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Veiculo.UpdateVehicle;

/// <summary>
/// Handler responsável por atualizar um veículo.
/// </summary>
public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, Result<VehicleModel>>
{
    private readonly IMapper _mapper;
    private readonly IVehicleRepository _vehicleRepository;

    public UpdateVehicleCommandHandler(IMapper mapper, IVehicleRepository vehicleRepository)
    {
        _mapper = mapper;
        _vehicleRepository = vehicleRepository;
    }
    
    public async Task<Result<VehicleModel>> Handle(UpdateVehicleCommand command, CancellationToken cancellationToken)
    {
        var vehicle = _mapper.Map<Vehicle>(command);

        var result = await _vehicleRepository.UpdateAsync(vehicle);

        return new()
        {
            Retorno = _mapper.Map<VehicleModel>(vehicle),
            Sucesso = result
        };
    }
}
