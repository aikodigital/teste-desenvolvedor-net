using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Infrastructure.Useful;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Veiculo.GetVehicleLine;

/// <summary>
/// Parâmetros ultilizados para listar as veículos por linha.
/// </summary>
public class GetVehicleLineQuery : VehicleModel, IRequest<Result<IEnumerable<VehicleModel>>>
{
}