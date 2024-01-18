using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportePublico.App.Commands.Veiculos.Create;
using TransportePublico.App.Commands.Veiculos.Delete;
using TransportePublico.App.Commands.Veiculos.Update;
using TransportePublico.App.Queries.Veiculos.GetAll;
using TransportePublico.App.Queries.Veiculos.GetById;
using TransportePublico.App.Queries.Veiculos.GetVeiculosByLinha;

namespace TransportePublico.Api.Controllers.Veiculos;

[ApiController]
[Route("api/veiculos")]
// [Authorize("Bearer")]
public class VeiculosController : ControllerBase
{
    private readonly IMediator _mediator;

    public VeiculosController(IMediator mediator) : base()
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var veiculos = await _mediator.Send(new GetAllVeiculosQuery());
        if (veiculos == null)
            return NotFound();
        return Ok(veiculos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var veiculo = await _mediator.Send(new GetVeiculoByIdQuery(id));
        if (veiculo == null)
            return NotFound();
        return Ok(veiculo);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] NewVeiculoDto veiculo)
    {
        var veiculoOk = await _mediator.Send(new CreateVeiculoCommand(veiculo));
        if (!veiculoOk)
            return BadRequest();
        return Ok("Veiculo is created.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateVeiculoDto veiculo)
    {
        veiculo.Id = id;
        var veiculoOk = await _mediator.Send(new UpdateVeiculoCommand(veiculo));
        if (!veiculoOk)
            return BadRequest();
        return Ok("Veiculo is updated.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var deletedVeiculo = await _mediator.Send(new DeleteVeiculoCommand(id));
        if (!deletedVeiculo)
            return BadRequest();
        return Ok("Veiculo is deleted.");
    }

    [HttpGet("veiculobylinha/{linhaId}")]
    public async Task<IActionResult> GetVeiculoByLinha(long linhaId)
    {
        var veiculos = await _mediator.Send(new GetVeiculosByLinhaQuery(linhaId));
        if (veiculos == null)
            return NotFound();
        return Ok(veiculos);
    }
}