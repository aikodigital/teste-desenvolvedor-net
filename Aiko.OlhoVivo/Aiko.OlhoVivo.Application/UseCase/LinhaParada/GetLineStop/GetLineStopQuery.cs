using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Infrastructure.Useful;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.LinhaParada.GetLineStop;

/// <summary>
/// Parâmetros ultilizados para listar oaparadas vinculas as linhas.
/// </summary>
public class GetLineStopQuery : LineStopModel, IRequest<Result<IEnumerable<LineModel>>>
{
}