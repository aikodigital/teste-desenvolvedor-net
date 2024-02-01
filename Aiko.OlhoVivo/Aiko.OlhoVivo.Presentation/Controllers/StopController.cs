using Aiko.OlhoVivo.Application.UseCase.Parada.AddStop;
using Aiko.OlhoVivo.Application.UseCase.Parada.DeleteStop;
using Aiko.OlhoVivo.Application.UseCase.Parada.GetStop;
using Aiko.OlhoVivo.Application.UseCase.Parada.UpdateStop;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aiko.OlhoVivo.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StopController : ControllerBase
{
    private readonly IMediator _mediator;

    public StopController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetStopQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        return Ok(await _mediator.Send(new GetStopQuery { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddStopCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] UpdateStopCommand command)
    {
        command.Id = id;
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        return Ok(await _mediator.Send(new DeleteStopCommand { Id = id }));
    }
}