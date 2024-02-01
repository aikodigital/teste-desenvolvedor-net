using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Infrastructure.Useful;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Linha.GetLine;

/// <summary>
/// Parâmetros ultilizados para listar os veículos.
/// </summary>
public class GetLineQuery : LineModel, IRequest<Result<IEnumerable<LineModel>>>
{
}