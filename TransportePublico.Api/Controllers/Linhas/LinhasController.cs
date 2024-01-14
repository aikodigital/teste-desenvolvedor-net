using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportePublico.App.Queries.Linhas.GetAll;
using TransportePublico.App.Queries.Linhas.GetById;

namespace TransportePublico.Api.Controllers.Linhas;

[ApiController]
[Produces("application/json")]
[Route("api/linhas")]
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

    // [HttpGet("{acaoId}")]
    // public async Task<IActionResult> ObterAcaoPorId(Guid acaoId)
    // {
    //     return OkResposta(await _mediator.Send(new ObterAcaoPorIdQuery(acaoId)));
    // }

    // [HttpPost]
    // public async Task<IActionResult> Inserir([FromBody] AcaoNovaDto acao)
    // {
    //     return OkResposta(await _mediator.Send(new InserirAcaoComando(acao)));
    // }

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> Excluir(Guid id)
    // {
    //     await _mediator.Send(new ExcluirAcaoComando(id));
    //     return OkResposta("OK");
    // }
}