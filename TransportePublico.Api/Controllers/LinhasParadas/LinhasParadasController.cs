using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportePublico.App.Commands.LinhasParadas.Associate;
using TransportePublico.App.Commands.LinhasParadas.Disassociate;
using TransportePublico.App.Queries.LinhasParadas.GetLinhasByParada;

namespace TransportePublico.Api.Controllers.LinhasParadas;

[ApiController]
[Route("api/linhasparadas")]
// [Authorize("Bearer")]
public class LinhasParadasController : ControllerBase
{
    private readonly IMediator _mediator;

    public LinhasParadasController(IMediator mediator) : base()
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLinhasByParada(long paradaId)
    {
        var linhas = await _mediator.Send(new GetLinhasByParadaQuery(paradaId));
        if (linhas == null)
            return NotFound();
        return Ok(linhas);
    }

    [HttpPost]
    public async Task<IActionResult> Associate(long linhaId, long paradaId)
    {
        var linhaOk = await _mediator.Send(new AssociateLinhasParadasCommand(linhaId, paradaId));
        if (!linhaOk)
            return BadRequest();
        return Ok("Linha and Parada are associated.");
    }

    [HttpDelete("{linhaId}/{paradaId}")]
    public async Task<IActionResult> Disassociate(long linhaId, long paradaId)
    {
        var linhaOk = await _mediator.Send(new DisassociateLinhasParadasCommand(linhaId, paradaId));
        if (!linhaOk)
            return BadRequest();
        return Ok("Linha and parada are disassociated.");
    }
}