using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AikoDigital.DataContext;
using AikoDigital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AikoDigital.Controllers
{
    /// <summary>
    /// Posição Controller foi criada para gerenciar todas as funcionalidades relacionadas diretamente a posição.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PosicaoVeiculoController : ControllerBase
    {
        /// <summary>
        /// Cadastro de posição veículo, você deve passar os dados da posição do veículo para serem armazenadas
        /// </summary>
        /// <response code="200">Se a posição for cadastrada com sucesso terá um retorno 200.</response>
        /// <response code="400">Se os parametros não forem supridos terá retorno 400.</response>
        /// <remarks> 
        /// Exemplo do corpo da requisição:
        /// {
        ///"Latitude":-8.807555,
        ///"Longitude":-63.888494,
        ///"VeiculoId": 1
        ///}
        ///OBS: é necessário já ter um veículo cadastrado, para que seja viculado uma posição a ele.
        /// </remarks> 
        [HttpPost]
        public async Task<ActionResult<PosicaoVeiculo>> Post([FromServices] ApiDataContext context, [FromBody] PosicaoVeiculo model)
        {
            if (model.VeiculoId > 0)
            {
                try
                {
                    context.PosicaoVeiculos.Add(model);
                    await context.SaveChangesAsync();
                    return Ok(model);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            return BadRequest();
        }
        /// <summary>
        /// Busca todas as posições de veículos gravados no banco de dados.
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<PosicaoVeiculo>>> Get([FromServices] ApiDataContext context)
        {
            if (ModelState.IsValid)
            {
                var posicaoVeiculos = await context.PosicaoVeiculos.ToListAsync();
                if (posicaoVeiculos != null)
                {
                    return Ok(posicaoVeiculos);
                }
            }
            return NotFound();
        }
        /// <summary>
        /// Busca posição do Veículo via ID.
        /// </summary>
        /// <response code="200">Se tiver alguma posição cadastrada com ID informado irá retornar o resultado com código 200.</response>
        /// <response code="404">Se o não for encotrada nenhuma posição vinculada a aquele veículo então terá retorno 404.</response>
        /// <response code="400">Se os parametros não forem supridos terá retorno 400.</response>
        [HttpGet]
        [Route("{veiculoId}")]
        public async Task<ActionResult<PosicaoVeiculo>> GetById([FromServices] ApiDataContext context, long veiculoId)
        {
            if (veiculoId > 0)
            {
                var posicaoVeiculos = context.PosicaoVeiculos.Where(x => x.VeiculoId == veiculoId);
                if (posicaoVeiculos != null)
                {
                    var result = await (from t in posicaoVeiculos
                                        orderby t.Id descending
                                        select t).FirstOrDefaultAsync();
                    if (result != null)
                    {
                        return Ok(result);

                    }
                }
                return NotFound();
            }
            return BadRequest();
        }

        /// <summary>
        /// Atualiza uma posição de veículo já cadastrada
        /// </summary>
        /// <response code="200">Caso tenha sido atualizada com sucesso, receber um retorno 200 com o corpo da atualização.</response>
        /// <response code="404">Se o não for encotrada nenhuma posição vinculada a aquele veículo então terá retorno 404.</response>
        /// <response code="400">Se os parametros não forem supridos terá retorno 400.</response>
        /// <remarks> 
        /// Exemplo do corpo da requisição:
        /// {
        ///"Latitude":-8.807875,
        ///"Longitude":-63.999658,
        ///"VeiculoId": 1
        ///}
        /// </remarks> 
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<PosicaoVeiculo>> Update([FromServices] ApiDataContext context, long id, [FromBody] PosicaoVeiculo model)
        {
            if (id > 0)
            {
                var posicaoVeiculo = await context.PosicaoVeiculos.FirstOrDefaultAsync(x => x.Id == id);
                if (posicaoVeiculo != null)
                {
                    posicaoVeiculo.Latitude = model.Latitude;
                    posicaoVeiculo.Longitude = model.Longitude;
                    posicaoVeiculo.VeiculoId = model.VeiculoId >= 1 ? model.VeiculoId : posicaoVeiculo.VeiculoId;
                    context.Update(posicaoVeiculo);
                    await context.SaveChangesAsync();
                    return Ok(posicaoVeiculo);
                }
                return NotFound();
            }
            return BadRequest();
        }
        /// <summary>
        /// Deleta uma posição de veículo, você deve informar um ID desejado para exclusão.
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<PosicaoVeiculo>> Delete([FromServices] ApiDataContext context, long id)
        {
            if (ModelState.IsValid)
            {
                var posicaoVeiculo = await context.PosicaoVeiculos.FirstOrDefaultAsync(x => x.Id == id);
                context.Remove(posicaoVeiculo);
                await context.SaveChangesAsync();
                return Ok(posicaoVeiculo);
            }
            return BadRequest();
        }
    }
}
