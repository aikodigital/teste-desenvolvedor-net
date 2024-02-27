using AikoDigital.Contexto;
using AikoDigital.Models;
using AikoDigital.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AikoDigital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinhaController : ControllerBase
    {
        private readonly string MensagemErro = "Erro interno no servidor";
        private readonly string MensagemLinhaNotFound = "Linha não encontrada";
        private readonly string MensagemParadaNotFound = "Parada não encontrada";
        private readonly LinhaRepository linhaRepository;
        private readonly ParadaRepository paradaRepository;
        
        public LinhaController(AppDbContext context) 
        { 
            linhaRepository = new LinhaRepository(context);
            paradaRepository = new ParadaRepository(context);
        }

        [HttpGet]
        public async Task<ActionResult<Linha>> Get()
        {
            try
            {
                var resultado = await linhaRepository.Get();
                if (resultado is not null && resultado.Count == uint.MinValue) return NotFound(MensagemLinhaNotFound);
                return Ok(resultado);
            }
            catch
            {
                return BadRequest(MensagemErro);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Linha>> GetById(long id)
        {
            try
            {
                var resultado = await linhaRepository.GetById(id);
                if (resultado is null) return NotFound(MensagemLinhaNotFound);
                return Ok(resultado);
            }
            catch
            {
                return BadRequest(MensagemErro);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Linha>> Post(Linha linha)
        {
            try
            {
                if (linha is null || !ModelState.IsValid) return BadRequest();

                await linhaRepository.Create(linha);

                return Ok();
            }
            catch
            {
                return BadRequest(MensagemErro);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Linha>> Put(long id, Linha linha)
        {
            try
            {
                if (id != linha.Id || linha is null || !ModelState.IsValid) return BadRequest();

                var objeto = await linhaRepository.GetById(id);
                
                if (objeto is null) return NotFound(MensagemLinhaNotFound);
                
                await linhaRepository.Update(id, linha);

                return Ok(linha);
            }
            catch
            {
                return BadRequest(MensagemErro);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Linha>> Delete(long id)
        {
            try
            {
                if (id <= uint.MinValue) return BadRequest();

                var linha = await linhaRepository.GetById(id);
                if (linha is null) return NotFound(MensagemLinhaNotFound);

                await linhaRepository.Delete(id);

                return NoContent();
            }
            catch
            {
                return BadRequest(MensagemErro);
            }
        
        }

        [HttpGet("LinhasPorParada/{id}")]
        public async Task<ActionResult<Linha>> LinhasPorParadas(long idParada)
        {
            try
            {
                if (idParada <= uint.MinValue) return BadRequest();

                var parada = await paradaRepository.GetById(idParada);
                if (parada is null) return NotFound(MensagemParadaNotFound);

                var linhas = await linhaRepository.GetLinhasParada(idParada);
                return Ok(linhas);
            }
            catch
            {
                return BadRequest(MensagemErro);
            }
        }

        

    }
}
