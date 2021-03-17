using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Commons.Dtos;
using Services.Linha;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LinhasController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] ListarTodasAsLinhas listarTodasAsLinhas)
        {
            var linhas = await listarTodasAsLinhas.Executar();

            return new ObjectResult(linhas);
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> Get([FromServices] ObterLinhaPorId obterLinhaloPorId, long id)
        {
            var linha = await obterLinhaloPorId.Executar(id);

            if (linha is null)
                return NotFound();

            return new ObjectResult(linha);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromServices] CadastrarLinha cadastrarLinha, LinhaDto linhaDto)
        {
            if (ModelState.IsValid) {
                await cadastrarLinha.Executar(linhaDto);

                return Ok();
            }

            return BadRequest(linhaDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromServices] EditarLinha editarLinha, LinhaDto linhaDto)
        {
            if (ModelState.IsValid) {
                await editarLinha.Executar(linhaDto);

                if (editarLinha.Notifications.Any()) {
                    return BadRequest(editarLinha.Notifications);
                }

                return Ok();
            }

            return BadRequest(linhaDto);
        }

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> Delete([FromServices] DeletarLinha deletarLinha, long id)
        {
            await deletarLinha.Executar(id);

            if (deletarLinha.Notifications.Any()) {
                return BadRequest(deletarLinha.Notifications);
            }

            return Ok();
        }
    }
}