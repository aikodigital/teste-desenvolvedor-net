using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Application.UseCase.Parada.AddStop;
using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Dto;
using Aiko.OlhoVivo.Infrastructure.Useful;
using AutoMapper;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Veiculo.AddVehicle;

/// <summary>
/// Handler responsável por cadastrar um novo veiculo.
/// </summary>
public class AddVehicleCommandHandler : IRequestHandler<AddVehicleCommand, Result<VehicleModel>>
{
    private readonly IMapper _mapper;
    private readonly IVehicleRepository _vehicleRepository;

    public AddVehicleCommandHandler(IMapper mapper, IVehicleRepository vehicleRepository)
    {
        _mapper = mapper;
        _vehicleRepository = vehicleRepository;
    }

    public async Task<Result<VehicleModel>> Handle(AddVehicleCommand command, CancellationToken cancellationToken)
    {
        var erros = Array.Empty<string>();

        var vehicle = _mapper.Map<Vehicle>(command);

        await _vehicleRepository.AddAsync(vehicle);

        return new()
        {
            Erros = erros,
            Retorno = _mapper.Map<VehicleModel>(vehicle),
            Sucesso = !erros.Any()
        };
    }
}