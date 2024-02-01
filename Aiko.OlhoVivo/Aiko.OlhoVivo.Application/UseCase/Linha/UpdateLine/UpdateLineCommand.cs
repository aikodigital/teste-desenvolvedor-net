using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Infrastructure.Useful;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Linha.UpdateLine;

/// <summary>
/// Parâmetros ultilizados para atualizar uma linha.
/// </summary>
public class UpdateLineCommand : LineModel, IRequest<Result<LineModel>>
{
}