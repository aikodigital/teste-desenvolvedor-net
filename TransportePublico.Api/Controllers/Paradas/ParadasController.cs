using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportePublico.App.Commands.Paradas.Create;
using TransportePublico.App.Commands.Paradas.Delete;
using TransportePublico.App.Commands.Paradas.Update;
using TransportePublico.App.Queries.Paradas.GetAll;
using TransportePublico.App.Queries.Paradas.GetById;

namespace TransportePublico.Api.Controllers.Paradas;

[ApiController]
[Route("api/paradas")]
// [Authorize("Bearer")]
public class ParadasController : ControllerBase
{
    private readonly IMediator _mediator;

    public ParadasController(IMediator mediator) : base()
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var paradas = await _mediator.Send(new GetAllParadasQuery());
        if (paradas == null)
            return NotFound();
        return Ok(paradas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var parada = await _mediator.Send(new GetParadaByIdQuery(id));
        if (parada == null)
            return NotFound();
        return Ok(parada);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] NewParadaDto parada)
    {
        var paradaOk = await _mediator.Send(new CreateParadaCommand(parada));
        if (!paradaOk)
            return BadRequest();
        return Ok("Linha is created.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] UpdateParadaDto parada)
    {
        var paradaOk = await _mediator.Send(new UpdateParadaCommand(parada));
        if (!paradaOk)
            return BadRequest();
        return Ok("Parada is updated.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var deletedParada = await _mediator.Send(new DeleteParadaCommand(id));
        if (!deletedParada)
            return BadRequest();
        return Ok("Parada is deleted.");
    }
}