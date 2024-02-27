using AikoDigital.Contexto;
using AikoDigital.Models;
using AikoDigital.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AikoDigital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosicaoVeiculoController : ControllerBase
    {
        private readonly string MensagemErro = "Erro interno no servidor";
        private readonly string MensagemPosicaoVeiculoNotFound = "Posição do veículo não encontrado";
        private readonly PosicaoVeiculoRepository posicaoVeiculoRepository;
        
        public PosicaoVeiculoController(AppDbContext context)
        {
            posicaoVeiculoRepository = new PosicaoVeiculoRepository(context);
        }

        [HttpGet]
        public async Task<ActionResult<PosicaoVeiculo>> Get()
        {
            try
            {
                var resultado = await posicaoVeiculoRepository.Get();
                if (resultado is not null && resultado.Count == uint.MinValue) return NotFound(MensagemPosicaoVeiculoNotFound);
                return Ok(resultado);
            }
            catch
            {
                return BadRequest(MensagemErro);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PosicaoVeiculo>> GetById(long id)
        {
            try
            {
                var resultado = await posicaoVeiculoRepository.GetById(id);
                if (resultado is null) return NotFound(MensagemPosicaoVeiculoNotFound);
                return Ok(resultado);
            }
            catch
            {
                return BadRequest(MensagemErro);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PosicaoVeiculo>> Post(PosicaoVeiculo posicaoVeiculo)
        {
            try
            {
                if (posicaoVeiculo is null || !ModelState.IsValid) return BadRequest();

                posicaoVeiculoRepository.Create(posicaoVeiculo);
                
                return Ok();
            }
            catch
            {
                return BadRequest(MensagemErro);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PosicaoVeiculo>> Put(long id, PosicaoVeiculo posicaoVeiculo)
        {
            try
            {
                if (id != posicaoVeiculo.Id || posicaoVeiculo is null || !ModelState.IsValid) return BadRequest();

                var objeto = await posicaoVeiculoRepository.GetById(id);
                if (objeto is null) return NotFound(MensagemPosicaoVeiculoNotFound);

                posicaoVeiculoRepository.Update(id, posicaoVeiculo);

                return Ok(objeto);
            }
            catch
            {
                return BadRequest(MensagemErro);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PosicaoVeiculo>> Delete(long id)
        {
            try
            {
                if (id <= uint.MinValue) return BadRequest();

                var posicaoVeiculo = await posicaoVeiculoRepository.GetById(id);
                if (posicaoVeiculo is null) return NotFound(MensagemPosicaoVeiculoNotFound);

                posicaoVeiculoRepository.Delete(id);

                return NoContent();
            }
            catch
            {
                return BadRequest(MensagemErro);
            }

        }
    }
}
