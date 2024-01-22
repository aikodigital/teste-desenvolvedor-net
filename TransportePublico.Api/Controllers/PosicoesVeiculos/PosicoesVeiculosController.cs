using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportePublico.App.Commands.PosicoesVeiculos.Create;
using TransportePublico.App.Commands.PosicoesVeiculos.Delete;
using TransportePublico.App.Commands.PosicoesVeiculos.Update;
using TransportePublico.App.Queries.PosicoesVeiculos.GetAll;
using TransportePublico.App.Queries.PosicoesVeiculos.GetById;

namespace TransportePublico.Api.Controllers.PosicoesVeiculos;

[ApiController]
[Route("api/posicoesveiculos")]
// [Authorize("Bearer")]
public class PosicoesVeiculosController : ControllerBase
{
    private readonly IMediator _mediator;

    public PosicoesVeiculosController(IMediator mediator) : base()
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var posicoes = await _mediator.Send(new GetAllPosicoesVeiculosQuery());
        if (posicoes == null)
            return NotFound();
        return Ok(posicoes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var posicao = await _mediator.Send(new GetPosicaoVeiculoByIdQuery(id));
        if (posicao == null)
            return NotFound();
        return Ok(posicao);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] NewPosicaoVeiculoDto posicaoVeiculo)
    {
        var posicaoVeiculoOk = await _mediator.Send(new CreatePosicaoVeiculoCommand(posicaoVeiculo));
        if (!posicaoVeiculoOk)
            return BadRequest();
        return Ok("Posição Veiculo is created.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] UpdatePosicaoVeiculoDto posicaoVeiculo)
    {
        var posicaoVeiculoOk = await _mediator.Send(new UpdatePosicaoVeiculoCommand(posicaoVeiculo));
        if (!posicaoVeiculoOk)
            return BadRequest();
        return Ok("Posição Veiculo is updated.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var deletedPosicaoVeiculo = await _mediator.Send(new DeletePosicaoVeiculoCommand(id));
        if (!deletedPosicaoVeiculo)
            return BadRequest();
        return Ok("Posição Veiculo is deleted.");
    }
}