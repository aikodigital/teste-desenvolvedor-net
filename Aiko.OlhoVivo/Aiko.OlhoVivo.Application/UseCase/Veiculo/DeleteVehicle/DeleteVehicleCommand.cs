using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Infrastructure.Useful;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Veiculo.DeleteVehicle;

/// <summary>
/// Parâmetros ultilizados para excluir um veículo.
/// </summary>
public class DeleteVehicleCommand : VehicleModel, IRequest<Result<VehicleModel>>
{
}