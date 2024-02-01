using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Infrastructure.Useful;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.PositionVehicle.DeletePositionVehicle;

/// <summary>
/// Parâmetros ultilizados para excluir uma posição veícular.
/// </summary>
public class DeletePositionVehicleCommand : VehiclePositionModel, IRequest<Result<VehiclePositionModel>>
{
}
