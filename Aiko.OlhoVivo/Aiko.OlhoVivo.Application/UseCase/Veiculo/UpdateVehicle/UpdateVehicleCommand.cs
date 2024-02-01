using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Infrastructure.Useful;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Veiculo.UpdateVehicle;

/// <summary>
/// Parâmetros ultilizados para atualizar um veículo.
/// </summary>
public class UpdateVehicleCommand : VehicleModel, IRequest<Result<VehicleModel>>
{
}