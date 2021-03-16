using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Commons.Dtos;
using Services.Linha;
using Services.Veiculo;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosPorLinhaController : ControllerBase
    {
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> Get([FromServices] ObterVeiculosPorLinhas obterVeiculosPorLinhas, long id)
        {
            var veiculosPorLinhas = await obterVeiculosPorLinhas.Executar(id);

            return new ObjectResult(veiculosPorLinhas);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromServices] VincularVeiculo vincularVeiculo, VeiculoNaLinhasDto veiculoNaLinhasDto)
        {
            await vincularVeiculo.Executar(veiculoNaLinhasDto);

            if (vincularVeiculo.Notifications.Any())
                return BadRequest(vincularVeiculo.Notifications);

            return Ok();
        }
    }
}