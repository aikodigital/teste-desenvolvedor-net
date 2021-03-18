using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AikoDigital.DataContext;
using AikoDigital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AikoDigital.Controllers
{/// <summary>
/// Veículo Controller foi criada para gerenciar todas as funcionalidades relacionadas diretamente a veículos.
/// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        /// <summary>
        /// Cadastro de Veiculo, você deve informar o nome, modelo e a linha onde ele pertence.
        /// </summary>
        /// <response code="200">Caso o veículo seja inserido com sucesso, o retorno será 200.</response>
        /// <response code="400">Caso não os parametros não preencham os requisitos terá um retorno código 400.</response>
        [HttpPost]
        public async Task<ActionResult<Veiculo>> Post([FromServices] ApiDataContext context, [FromBody] Veiculo model)
        {
            if (model.LinhaId > 0 && model.Modelo != null && model.Name != null)
            {
                try
                {
                    context.Veiculos.Add(model);
                    await context.SaveChangesAsync();
                    return Ok(model);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            else
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Busca todos os Veículos cadastrados no banco de dados.
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Veiculo>>> Get([FromServices] ApiDataContext context)
        {
            if (ModelState.IsValid)
            {
                var veiculos = await context.Veiculos.ToListAsync();
                if (veiculos != null)
                {
                    return Ok(veiculos);
                }
            }
            return NotFound();
        }
        /// <summary>
        /// Busca de veículo por ID, você deve informar o ID do veículo desejado.
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Veiculo>> GetById([FromServices] ApiDataContext context, long id)
        {

            if (ModelState.IsValid)
            {
                var veiculos = await context.Veiculos.FirstOrDefaultAsync(x => x.Id == id);
                if (veiculos != null)
                {
                    return Ok(veiculos);
                }
            }
            return NotFound();
        }

        /// <summary>
        /// Busca de veículo por Linha, você deve informar o ID da linha desejada.
        /// </summary>
        [HttpGet]
        [Route("{LinhaId}/Linhas")]
        public async Task<ActionResult<Veiculo>> GetByLinha([FromServices] ApiDataContext context, long LinhaId)
        {
            if (ModelState.IsValid)
            {
                var veiculos = await context.Veiculos.Where(x => x.LinhaId == LinhaId).ToListAsync();
                if (veiculos.Count > 0)
                {
                    return Ok(veiculos);
                }
            }
            return NotFound();
        }

        /// <summary>
        /// Atualização de dados do Veículo, você deve passar o ID do veículo que deseja atualizar e no corpo da requisição os dados a serem alterados como nome, modelo e Linha ID
        /// </summary>
        /// <response code="200">Se houver for atualizado com sucesso, terá um retorno 200.</response>
        /// <response code="400">Se o ID informado for menor que 0, terá um retorno 400.</response>
        /// <response code="404">Se o ID informado não corresponder a nenhum veículo cadastrado no banco irá ter retorno 404.</response>
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Veiculo>> Update([FromServices] ApiDataContext context, long id, [FromBody] Veiculo model)
        {
            if (id > 0)
            {
                var veiculo = await context.Veiculos.FirstOrDefaultAsync(x => x.Id == id);
                if (veiculo != null)
                {
                    veiculo.Name = model.Name;
                    veiculo.Modelo = model.Modelo;
                    veiculo.LinhaId = model.LinhaId;
                    context.Update(veiculo);
                    await context.SaveChangesAsync();
                    return Ok(veiculo);
                }
                return NotFound();
            }
            return BadRequest();
        }
        /// <summary>
        /// Deletar um veículo cadastrado, você deve informar um ID do veículo que deseja deletar, utilize essa funcionalidade com cuidado!!
        /// </summary>
        /// <response code="200">Se o veículo for deletado com sucesso, terá um retorno 200.</response>
        /// <response code="400">Se o ID informado for menor que 0, terá um retorno 400.</response>
        /// <response code="404">Se o ID informado não corresponder a nenhum veículo cadastrado no banco irá ter retorno 404.</response>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Veiculo>> Delete([FromServices] ApiDataContext context, long id)
        {
            if (id > 0)
            {
                var veiculo = await context.Veiculos.FirstOrDefaultAsync(x => x.Id == id);
                if (veiculo != null)
                {
                    context.Remove(veiculo);
                    await context.SaveChangesAsync();
                    return Ok(veiculo);
                }
                return NotFound();
            }
            return BadRequest();
        }
    }
}
