using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Infrastructure.Useful;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Parada.UpdateStop;

/// <summary>
/// Parâmetros ultilizados para atualizar uma parada.
/// </summary>
public class UpdateStopCommand : StopModel, IRequest<Result<StopModel>>
{
}