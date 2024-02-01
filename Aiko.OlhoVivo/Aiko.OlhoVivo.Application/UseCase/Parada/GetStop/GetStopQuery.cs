using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Infrastructure.Useful;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Parada.GetStop;

/// <summary>
/// Parâmetros ultilizados para listar as paradas.
/// </summary>
public class GetStopQuery : StopModel, IRequest<Result<IEnumerable<StopModel>>>
{
}