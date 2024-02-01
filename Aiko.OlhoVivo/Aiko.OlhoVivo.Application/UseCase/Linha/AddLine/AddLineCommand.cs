using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Infrastructure.Useful;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Linha.AddLine;

/// <summary>
/// Parâmetros ultilizados para cadastrar uma nova linha.
/// </summary>
public class AddLineCommand : LineModel, IRequest<Result<LineModel>> 
{
}