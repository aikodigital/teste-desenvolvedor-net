using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Infrastructure.Useful;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.PositionVehicle.GetPositionVehicle;

/// <summary>
/// Parâmetros ultilizados para listar as posições veículares cadastradas.
/// </summary>
public class GetVehiclePositionQuery : VehiclePositionModel, IRequest<Result<IEnumerable<VehiclePositionModel>>>
{
}
