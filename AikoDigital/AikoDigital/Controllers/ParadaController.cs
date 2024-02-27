using AikoDigital.Contexto;
using AikoDigital.Models;
using AikoDigital.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AikoDigital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParadaController : ControllerBase
    {
        private readonly string MensagemErro = "Erro interno no servidor";
        private readonly string MensagemParadaNotFound = "Parada não encontrada";
        private readonly ParadaRepository paradaRepository;
        
        public ParadaController(AppDbContext context)
        {
            paradaRepository = new ParadaRepository(context);
        }

        [HttpGet]
        public async Task<ActionResult<Parada>> Get()
        {
            try
            {
                var resultado = await paradaRepository.Get();
                if (resultado is not null && resultado.Count == uint.MinValue) return NotFound(MensagemParadaNotFound);
                return Ok(resultado);
            }
            catch
            {
                return BadRequest(MensagemErro);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Parada>> GetById(long id)
        {
            try
            {
                var resultado = await paradaRepository.GetById(id);
                if (resultado is null) return NotFound(MensagemParadaNotFound);
                return Ok(resultado);
            }
            catch
            {
                return BadRequest(MensagemErro);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Parada>> Post(Parada parada)
        {
            try
            {
                if (parada is null || !ModelState.IsValid) return BadRequest();

                await paradaRepository.Create(parada);
                
                return Ok();
            }
            catch
            {
                return BadRequest(MensagemErro);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Parada>> Put(long id, Parada parada)
        {
            try
            {
                if (id != parada.Id || parada is null || !ModelState.IsValid) return BadRequest();

                var objeto = await paradaRepository.GetById(id);
                if (objeto is null) return NotFound(MensagemParadaNotFound);

                await paradaRepository.Update(id, parada);

                return Ok(parada);
            }
            catch
            {
                return BadRequest(MensagemErro);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Parada>> Delete(long id)
        {
            try
            {
                if (id <= uint.MinValue) return BadRequest();

                var parada = await paradaRepository.GetById(id);
                if (parada is null) return NotFound(MensagemParadaNotFound);

                await paradaRepository.Delete(id);
                
                return NoContent();
            }
            catch
            {
                return BadRequest(MensagemErro);
            }

        }
    }
}
