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
    public class LinhasController : ControllerBase
    {
        private readonly ILinhaService _service;

        public LinhasController(ILinhaService service)
        {
            _service = service;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id){
            try{
                var result = await _service.FindByIdLinhaAsync(id);
                if (result == null) return NotFound("Linha não encontrada");

                return Ok(result);
            }catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao procurar a linha: {ex.Message} ");
            }
        }
        
       
        [HttpGet]
        public async Task<IActionResult> Get(){
            try{
                var result = await _service.GetAllLinhasAsync();
                if (result == null) return NotFound("Nenhuma linha encontrada");

                return Ok(result);
            }catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao procurar as Linhas: {ex.Message} ");
            }
        }

        [HttpGet("parada/{paradaId}")]
        public async Task<IActionResult> GetLinhasByParadas(long paradaId){
            try {
                var result = await _service.FindAllLinhasByParadasAsync(paradaId);
                if(result == null) return NotFound("Nenhuma Linha encontrada");
                return Ok(result);

            }catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao procurar as Linhas: {ex.Message} ");
            }
        }

        [HttpGet("buscarPorNome/{pageSize}/{page}")]
        public async Task<IActionResult> GetByNameSearchPage(int pageSize, int page, [FromQuery] string nome){
            try {
                var result = await _service.FindByNameSearchPage(nome, page, pageSize);
                return Ok(result);

            }catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao paginar as linhas: {ex.Message} ");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Linha linha){
            try{
                var result = await _service.AddLinhaAsync(linha);
                if(result == null) return BadRequest("Erro ao inserir a linha");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao cadastrar a linha: {ex.Message} ");
            }
        }

 
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, LinhaDTO linhaDTO)
        {
            try
            {
                var result = await _service.UpdateLinhaAsync(id, linhaDTO);
                if (result == null) return BadRequest("Erro em procurar as informações da Linha");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao atualizar as informações da Linha: {ex.Message} ");
            }
        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                return await _service.DeleteLinhaAsync(id) ? 
                    Ok("Deletado") : 
                    BadRequest("Não foi possivel deletar a Linha");
;
            }catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno ao deletar a Linha: {ex.Message}");
            }
        }
    }
}