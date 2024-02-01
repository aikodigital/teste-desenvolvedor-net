using Aiko.OlhoVivo.Application.UseCase.LinhaParada.AddLineStop;
using Aiko.OlhoVivo.Application.UseCase.LinhaParada.GetLineStop;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aiko.OlhoVivo.Presentation.Controllers;


[Route("api/[controller]")]
[ApiController]
public class LineStopController : ControllerBase
{
    private readonly IMediator _mediator;

    public LineStopController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        return Ok(await _mediator.Send(new GetLineStopQuery { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddLineStopCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}