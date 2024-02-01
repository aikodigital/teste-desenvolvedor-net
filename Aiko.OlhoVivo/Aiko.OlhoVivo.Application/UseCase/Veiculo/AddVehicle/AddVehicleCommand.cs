using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Infrastructure.Useful;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Veiculo.AddVehicle;

/// <summary>
/// Parâmetros ultilizados para cadastrar um novo veículo.
/// </summary>
public class AddVehicleCommand : VehicleModel, IRequest<Result<VehicleModel>>
{
}