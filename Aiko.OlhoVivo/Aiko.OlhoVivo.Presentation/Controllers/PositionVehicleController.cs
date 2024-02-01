using Aiko.OlhoVivo.Application.UseCase.PositionVehicle.AddPositionVehicle;
using Aiko.OlhoVivo.Application.UseCase.PositionVehicle.DeletePositionVehicle;
using Aiko.OlhoVivo.Application.UseCase.PositionVehicle.GetPositionVehicle;
using Aiko.OlhoVivo.Application.UseCase.PositionVehicle.UpdatePositionVehicle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aiko.OlhoVivo.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PositionVehicleController : ControllerBase
{
    private readonly IMediator _mediator;

    public PositionVehicleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetVehiclePositionQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        return Ok(await _mediator.Send(new GetVehiclePositionQuery { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddPositionVehicleCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] UpdatePositionVehicleCommand command)
    {
        command.Id = id;
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        return Ok(await _mediator.Send(new DeletePositionVehicleCommand { Id = id }));
    }
}