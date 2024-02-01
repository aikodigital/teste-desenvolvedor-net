using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Application.UseCase.Parada.DeleteStop;
using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Useful;
using AutoMapper;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Veiculo.DeleteVehicle;

/// <summary>
/// Handler responsável por excluir um veículo.
/// </summary>
public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, Result<VehicleModel>>
{
    private readonly IMapper _mapper;
    private readonly IVehicleRepository _vehicleRepository;

    public DeleteVehicleCommandHandler(IMapper mapper, IVehicleRepository vehicleRepository)
    {
        _mapper = mapper;
        _vehicleRepository = vehicleRepository;
    }

    public async Task<Result<VehicleModel>> Handle(DeleteVehicleCommand command, CancellationToken cancellationToken)
    {
        var erros = Array.Empty<string>();

        var vehicle = (await _vehicleRepository.ListAsync(command.Id)).First();

        await _vehicleRepository.DeleteAsync(vehicle);

        return new()
        {
            Erros = erros,
            Retorno = _mapper.Map<VehicleModel>(vehicle),
            Sucesso = !erros.Any()
        };
    }
}