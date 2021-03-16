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
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoService _service;

        public VeiculosController(IVeiculoService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var result = await _service.FindByIdVeiculoAsync(id);
                if (result == null) return NotFound("Veiculo não encontrado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao procurar o Veiculo: {ex.Message} ");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _service.GetAllVeiculosAsync();
                if (result == null) return NotFound("Nenhuma Veiculo encontrado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao procurar os Veiculos: {ex.Message} ");
            }
        }

        [HttpGet("linha/{linhaId}")]
        public async Task<IActionResult> GetVeiculosByLinha(long linhaId)
        {
            try
            {
                var result = await _service.FindAllVeiculosByLinhasAsync(linhaId);
                if (result == null) return NotFound("Nenhuma Veiculo encontrado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao procurar os Veiculos: {ex.Message} ");
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
        [HttpPost]
        public async Task<IActionResult> Post(VeiculoDTO veiculoDTO)
        {
            try
            {
                var result = await _service.AddVeiculoAsync(veiculoDTO);
                if (result == null) return BadRequest("Erro ao cadastrar o Veiculo");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao cadastrar o Veiculo: {ex.Message} ");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, VeiculoDTO veiculoDTO)
        {
            try
            {
                var result = await _service.UpdateVeiculoAsync(id, veiculoDTO);
                if (result == null) return BadRequest("Erro em alterar os dados do Veiculo");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro em atualizar as informações do Veiculo: {ex.Message} ");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                return await _service.DeleteVeiculoAsync(id) ?
                    Ok("Deletado") :
                    BadRequest("Não foi possivel deletar o Veiculo");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao deletar o Veiculo: {ex.Message}");
            }
        }
    }
}