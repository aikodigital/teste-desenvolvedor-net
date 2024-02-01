using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Infrastructure.Useful;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Parada.AddStop;

/// <summary>
/// Parâmetros ultilizados para cadastrar uma nova parada.
/// </summary>
public class AddStopCommand : StopModel, IRequest<Result<StopModel>>
{
}