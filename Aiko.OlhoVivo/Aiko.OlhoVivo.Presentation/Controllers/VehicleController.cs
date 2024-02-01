using Aiko.OlhoVivo.Application.UseCase.Veiculo.AddVehicle;
using Aiko.OlhoVivo.Application.UseCase.Veiculo.DeleteVehicle;
using Aiko.OlhoVivo.Application.UseCase.Veiculo.GetVehicle;
using Aiko.OlhoVivo.Application.UseCase.Veiculo.GetVehicleLine;
using Aiko.OlhoVivo.Application.UseCase.Veiculo.UpdateVehicle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aiko.OlhoVivo.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehicleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("vehicleLine/{id}")]
    public async Task<IActionResult> GetVehicleLine(long id)
    {
        return Ok(await _mediator.Send(new GetVehicleLineQuery { Id = id }));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetVehicleQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        return Ok(await _mediator.Send(new GetVehicleQuery { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddVehicleCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] UpdateVehicleCommand command)
    {
        command.Id = id;
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        return Ok(await _mediator.Send(new DeleteVehicleCommand { Id = id }));
    }
}