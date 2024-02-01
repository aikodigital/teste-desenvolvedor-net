using Aiko.OlhoVivo.Application.UseCase.Linha.AddLine;
using Aiko.OlhoVivo.Application.UseCase.Linha.Delete;
using Aiko.OlhoVivo.Application.UseCase.Linha.GetLine;
using Aiko.OlhoVivo.Application.UseCase.Linha.UpdateLine;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Aiko.OlhoVivo.Presentation.Controllers;

[SwaggerTag("Permite criar, ler, atualizar, excluir e vincular objetos como linha, veículo, parada e posição.")]
[Route("[controller]")]
[ApiController]
public class LineController : ControllerBase
{
    private readonly IMediator _mediator;

    public LineController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetLineQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        return Ok(await _mediator.Send(new GetLineQuery { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddLineCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] UpdateLineCommand command)
    {
        return Ok(await _mediator.Send(new UpdateLineCommand { Name = command.Name, Id = id}));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        return Ok(await _mediator.Send(new DeleteLineCommand { Id = id }));
    }
}