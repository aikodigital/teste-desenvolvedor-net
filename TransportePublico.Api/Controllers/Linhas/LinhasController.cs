using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportePublico.App.Commands.Linhas.Create;
using TransportePublico.App.Commands.Linhas.Delete;
using TransportePublico.App.Commands.Linhas.Update;
using TransportePublico.App.Queries.Linhas.GetAll;
using TransportePublico.App.Queries.Linhas.GetById;

namespace TransportePublico.Api.Controllers.Linhas;

[ApiController]
[Route("api/linhas")]
// [Authorize("Bearer")]
public class LinhasController : ControllerBase
{
    private readonly IMediator _mediator;

    public LinhasController(IMediator mediator) : base()
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var linhas = await _mediator.Send(new GetAllLinhasQuery());
        if (linhas == null)
            return NotFound();
        return Ok(linhas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var linha = await _mediator.Send(new GetLinhaByIdQuery(id));
        if (linha == null)
            return NotFound();
        return Ok(linha);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] NewLinhaDto linha)
    {
        var linhaOk = await _mediator.Send(new CreateLinhaCommand(linha));
        if (!linhaOk)
            return BadRequest();
        return Ok("Linha is created.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] UpdateLinhaDto linha)
    {
        var linhaOk = await _mediator.Send(new UpdateLinhaCommand(linha));
        if (!linhaOk)
            return BadRequest();
        return Ok("Linha is updated.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var deletedLinha = await _mediator.Send(new DeleteLinhaCommand(id));
        if (!deletedLinha)
            return BadRequest();
        return Ok("Linha is deleted.");
    }
}