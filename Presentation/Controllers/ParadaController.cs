using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParadaController : ControllerBase
    {
        private readonly ParadaService service;

        public ParadaController(ParadaService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Listagem de paradas a partir da posição (ponto).
        /// </summary>
        /// <param name="latitude">Latitude da posição (ponto).</param>
        /// <param name="longitude">Longitude da posição (ponto).</param>
        /// <param name="quantidade">Quantidade de paradas a serem retornadas a partir da posição (ponto).</param>
        /// <returns></returns>
        [HttpGet("ListarPorPosicao")]
        public IActionResult ListarPorPosicao(double latitude, double longitude, int quantidade)
        {
            var dados = service.ListarPorPosicao(latitude, longitude, quantidade);

            return Ok(new SaidaViewModel(dados));
        }

        [HttpGet("Consultar/{id}")]
        public IActionResult Consultar(int id)
        {
            var dados = service.Consultar(id);

            return Ok(new SaidaViewModel(dados));
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var dados = service.Listar();

            return Ok(new SaidaViewModel(dados));
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastar([FromBody]ParadaViewModel entrada)
        {
            service.Cadastrar(entrada);

            return Ok(new SaidaViewModel(null));
        }

        [HttpPut("Alterar")]
        public IActionResult Alterar([FromBody]ParadaViewModel entrada)
        {
            service.Alterar(entrada);

            return Ok(new SaidaViewModel(null));
        }

        [HttpDelete("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            service.Excluir(id);

            return Ok(new SaidaViewModel(null));
        }
    }
}