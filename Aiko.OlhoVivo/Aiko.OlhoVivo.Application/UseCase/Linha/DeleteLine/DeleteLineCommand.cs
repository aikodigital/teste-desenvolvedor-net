using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Infrastructure.Useful;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Linha.Delete;

/// <summary>
/// Parâmetros ultilizados para excluir uma linha.
/// </summary>
public class DeleteLineCommand : LineModel, IRequest<Result<LineModel>>
{
}