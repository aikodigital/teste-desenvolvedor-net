using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Infrastructure.Useful;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.PositionVehicle.AddPositionVehicle;

/// <summary>
/// Parâmetros ultilizados para cadastrar uma nova posição do veículo..
/// </summary>
public class AddPositionVehicleCommand : VehiclePositionModel, IRequest<Result<VehiclePositionModel>>
{
}
