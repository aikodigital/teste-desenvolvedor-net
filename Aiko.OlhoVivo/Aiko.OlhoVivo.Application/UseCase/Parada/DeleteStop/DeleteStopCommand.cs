using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Infrastructure.Useful;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Parada.DeleteStop;

/// <summary>
/// Parâmetros ultilizados para excluir uma parada.
/// </summary>
public class DeleteStopCommand : StopModel, IRequest<Result<StopModel>>
{
}