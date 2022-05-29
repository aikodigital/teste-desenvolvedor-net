using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosicaoVeiculoController : ControllerBase
    {
        private readonly PosicaoVeiculoService service;

        public PosicaoVeiculoController(PosicaoVeiculoService service)
        {
            this.service = service;
        }

        [HttpGet("Consultar/{id}")]
        public IActionResult Consultar(int id)
        {
            var dados = service.Consultar(id);

            return Ok(new SaidaViewModel(dados));
        }

        /// <summary>
        /// Listagem de posições do veículo.
        /// </summary>
        /// <param name="id">Identificador do veículo.</param>
        /// <param name="dataInicio">Data única ou inicial do momento que o veículo operava. Quando for data única (sem final) será utilizado o dia inteiro.</param>
        /// <param name="dataFim">Data final do momento que o veículo operava.</param>
        /// <returns></returns>
        [HttpGet("ListarPorVeiculo/{id}")]
        public IActionResult ListarPorVeiculo(int id, [FromQuery]DateTime? dataInicio, [FromQuery]DateTime? dataFim)
        {
            var dados = service.Listar(id, dataInicio, dataFim);

            return Ok(new SaidaViewModel(dados));
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastar([FromBody]PosicaoVeiculoViewModel entrada)
        {
            service.Cadastrar(entrada);

            return Ok(new SaidaViewModel(null));
        }

        [HttpPut("Alterar")]
        public IActionResult Alterar([FromBody]PosicaoVeiculoViewModel entrada)
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