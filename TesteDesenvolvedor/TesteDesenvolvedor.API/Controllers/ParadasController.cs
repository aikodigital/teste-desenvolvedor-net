using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Services.DTOs;
using TesteDesenvolvedor.Services.Interface;

namespace TesteDesenvolvedor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParadasController : ControllerBase
    {
        private readonly IParadaService _service;

        public ParadasController(IParadaService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var result = await _service.FindByIdParadaAsync(id);
                if (result == null) return NotFound("Parada não encontrada");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao procurar a Parada: {ex.Message} ");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _service.GetAllParadasAsync();
                if (result == null) return NotFound("Nenhuma parada encontrada");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao procurar as Paradas: {ex.Message} ");
            }
        }

        [HttpGet("buscarPorNome/{pageSize}/{page}")]
        public async Task<IActionResult> GetByNameSearchPage(int pageSize, int page, [FromQuery] string nome)
        {
            try
            {
                var result = await _service.FindByNameSearchPage(nome, page, pageSize);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao paginar as linhas: {ex.Message} ");
            }
        }

        [HttpGet("posicao/")]
        public async Task<IActionResult> Get([FromQuery] double latitude, [FromQuery] double longitude, [FromQuery] double distance)
        {
            try
            {
                var result = await _service.FindParadaByPosicao(latitude, longitude, distance);
                if (result == null) return NotFound("Nenhuma Parada encontrada, por favor aumente a distancia de procura");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao procurar as Paradas: {ex.Message} ");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Parada parada)
        {
            try
            {
                var result = await _service.AddParadaAsync(parada);
                if (result == null) return BadRequest("Erro ao cadastrar a Parada");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao cadastrar a Parada: {ex.Message} ");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, ParadaDTO paradaDTO)
        {
            try
            {
                var result = await _service.UpdateParadaAsync(id, paradaDTO);
                if (result == null) return BadRequest("Erro em alterar os dados da Parada");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro em atualizar as informações da parada: {ex.Message} ");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                return await _service.DeleteParadaAsync(id) ?
                    Ok("Deletado") :
                    BadRequest("Não foi possivel deletar a Parada");
                ;
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao deletar a Parada: {ex.Message}");
            }
        }
    }
}