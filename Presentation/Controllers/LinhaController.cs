using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinhaController : ControllerBase
    {
        private readonly LinhaService service;

        public LinhaController(LinhaService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Listagem de linhas a partir da parada.
        /// </summary>
        /// <param name="id">Identificador da parada.</param>
        /// <returns></returns>
        [HttpGet("ListarPorParada/{id}")]
        public IActionResult ListarPorParada(int id)
        {
            var dados = service.ListarPorParada(id);

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
        public IActionResult Cadastar([FromBody]IdNomeViewModel entrada)
        {
            service.Cadastrar(entrada);

            return Ok(new SaidaViewModel(null));
        }

        [HttpPut("Alterar")]
        public IActionResult Alterar([FromBody]IdNomeViewModel entrada)
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