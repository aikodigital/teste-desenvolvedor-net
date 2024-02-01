using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Infrastructure.Useful;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.PositionVehicle.UpdatePositionVehicle;

/// <summary>
/// Parâmetros ultilizados para atualizar uma parada veícular.
/// </summary>
public class UpdatePositionVehicleCommand : VehiclePositionModel, IRequest<Result<VehiclePositionModel>>
{
}