using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Infrastructure.Useful;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Veiculo.GetVehicle;

/// <summary>
/// Parâmetros ultilizados para listar as paradas.
/// </summary>
public class GetVehicleQuery : VehicleModel, IRequest<Result<IEnumerable<VehicleModel>>>
{
}