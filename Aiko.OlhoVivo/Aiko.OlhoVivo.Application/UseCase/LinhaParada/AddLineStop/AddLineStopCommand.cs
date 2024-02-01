using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Infrastructure.Useful;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.LinhaParada.AddLineStop;

public class AddLineStopCommand : LineStopModel, IRequest<Result<LineStopModel>>
{
}