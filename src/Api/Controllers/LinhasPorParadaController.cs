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
    public class LinhasPorParadaController : ControllerBase
    {
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> Get([FromServices] ObterLinhasPorParada obterLinhasPorParada, long id)
        {
            var linhasPorParada = await obterLinhasPorParada.Executar(id);

            return new ObjectResult(linhasPorParada);
        }

        [HttpGet]
        [Route("{latitude:double}/{longitude:double}")]
        public async Task<IActionResult> Get([FromServices] ObterLinhasPorParada obterLinhasPorParada, double latitude, double longitude)
        {
            var linhasPorParada = await obterLinhasPorParada.Executar(latitude, longitude);

            return new ObjectResult(linhasPorParada);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromServices] VincularParada vincularParada, ParadaNaLinhaDto paradaNaLinhaDto)
        {
            await vincularParada.Executar(paradaNaLinhaDto);

            if (vincularParada.Notifications.Any())
                return BadRequest(vincularParada.Notifications);

            return Ok();
        }

        [HttpDelete]
        [Route("{linhaId:long}/{paradaId:long}")]
        public async Task<IActionResult> Delete([FromServices] DesvincularParada desvincularParada, long linhaId, long paradaId)
        {
            await desvincularParada.Executar(linhaId, paradaId);

            if (desvincularParada.Notifications.Any())
                return BadRequest(desvincularParada.Notifications);

            return Ok();
        }
    }
}