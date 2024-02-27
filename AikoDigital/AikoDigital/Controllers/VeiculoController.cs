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
    public class VeiculoController : ControllerBase
    {
        private readonly string MensagemErro = "Erro interno no servidor";
        private readonly string MensagemVeiculoNotFound = "Veículo não encontrado";
        private readonly string MensagemLinhaNotFound = "Linha não encontrada";
        private readonly VeiculoRepository veiculoRepository;
        private readonly LinhaRepository linhaRepository;

        public VeiculoController(AppDbContext context)
        {
            linhaRepository = new LinhaRepository(context);
            veiculoRepository = new VeiculoRepository(context);
        }

        [HttpGet]
        public async Task<ActionResult<Veiculo>> Get()
        {
            try
            {
                var resultado = await veiculoRepository.Get();
                if (resultado is not null && resultado.Count == uint.MinValue) return NotFound(MensagemVeiculoNotFound);
                return Ok(resultado);
            }
            catch
            {
                return BadRequest(MensagemErro);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> GetById(long id)
        {
            try
            {
                var resultado = await veiculoRepository.GetById(id);
                if (resultado is null) return NotFound(MensagemVeiculoNotFound);
                return Ok(resultado);
            }
            catch
            {
                return BadRequest(MensagemErro);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Veiculo>> Post(Veiculo veiculo)
        {
            try
            {
                if (veiculo is null || !ModelState.IsValid) return BadRequest();

                await veiculoRepository.Create(veiculo);
                
                return Ok();
            }
            catch
            {
                return BadRequest(MensagemErro);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Veiculo>> Put(long id, Veiculo veiculo)
        {
            try
            {
                if (id != veiculo.Id || veiculo is null || !ModelState.IsValid) return BadRequest();

                var objeto = await veiculoRepository.GetById(id);
                if (objeto is null) return NotFound(MensagemVeiculoNotFound);

                await veiculoRepository.Update(id, veiculo);

                return Ok(objeto);
            }
            catch
            {
                return BadRequest(MensagemErro);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Veiculo>> Delete(long id)
        {
            try
            {
                if (id <= uint.MinValue) return BadRequest();

                var veiculo = await veiculoRepository.GetById(id);
                if (veiculo is null) return NotFound(MensagemVeiculoNotFound);

                await veiculoRepository.Delete(id);
                
                return NoContent();
            }
            catch
            {
                return BadRequest(MensagemErro);
            }

        }

        [HttpGet("VeiculosPorLinha/{id}")]
        public async Task<ActionResult<Veiculo>> VeiculosPorLinha(long idLinha)
        {
            if (idLinha <= uint.MinValue) return BadRequest();

            var linha = await linhaRepository.GetById(idLinha);
            if (linha is null) return NotFound(MensagemLinhaNotFound);

            var veiculos = await veiculoRepository.GetVeiculosPorLinha(idLinha);

            return Ok(veiculos);
        }
    }
}
