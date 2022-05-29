using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly VeiculoService service;

        public VeiculoController(VeiculoService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Listagem de veículos a partir da linha.
        /// </summary>
        /// <param name="id">Identificador da linha.</param>
        /// <param name="dataInicio">Data única ou inicial do momento que o veículo operava na linha. Quando for data única (sem final) será utilizado o dia inteiro.</param>
        /// <param name="dataFim">Data final do momento que o veículo operava na linha.</param>
        /// <returns></returns>
        [HttpGet("ListarPorLinha/{id}")]
        public IActionResult ListarPorLinha(int id, [FromQuery]DateTime? dataInicio, [FromQuery]DateTime? dataFim)
        {
            var dados = service.ListarPorLinha(id, dataInicio, dataFim);

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
        public IActionResult Cadastar([FromBody]VeiculoViewModel entrada)
        {
            service.Cadastrar(entrada);

            return Ok(new SaidaViewModel(null));
        }

        [HttpPut("Alterar")]
        public IActionResult Alterar([FromBody]VeiculoViewModel entrada)
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