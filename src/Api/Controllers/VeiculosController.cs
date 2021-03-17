using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Commons.Dtos;
using Services.Veiculo;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] ListarTodosOsVeiculos listarTodosOsVeiculos)
        {
            var veiculos = await listarTodosOsVeiculos.Executar();

            return new ObjectResult(veiculos);
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> Get([FromServices] ObterVeiculoPorId obterVeiculoPorId, long id)
        {
            var veiculo = await obterVeiculoPorId.Executar(id);

            if (veiculo is null)
                return NotFound();

            return new ObjectResult(veiculo);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromServices] CadastrarVeiculo cadastrarVeiculo, VeiculoDto veiculoDto)
        {
            if (ModelState.IsValid) {
                await cadastrarVeiculo.Executar(veiculoDto);

                return Ok();
            }

            return BadRequest(veiculoDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromServices] EditarVeiculo editarVeiculo, VeiculoDto veiculoDto)
        {
            if (ModelState.IsValid) {
                await editarVeiculo.Executar(veiculoDto);

                if (editarVeiculo.Notifications.Any()) {
                    return BadRequest(editarVeiculo.Notifications);
                }

                return Ok();
            }

            return BadRequest(veiculoDto);
        }

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> Delete([FromServices] DeletarVeiculo deletarVeiculo, long id)
        {
            await deletarVeiculo.Executar(id);

            if (deletarVeiculo.Notifications.Any()) {
                return BadRequest(deletarVeiculo.Notifications);
            }

            return Ok();
        }
    }
}