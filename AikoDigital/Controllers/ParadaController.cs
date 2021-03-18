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
    /// Parada Controller foi criada para gerenciar todas as funcionalidades relacionadas diretamente a paradas.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ParadaController : Controller
    {
        /// <summary>
        /// Cadastro de Paradas, você deve informar no corpo, nome da parada,longitude, latitude.
        /// </summary>
        /// <response code="200">Se houver alguma parada cadastrada com esse mesmo ID será retornada com código 200.</response>
        /// <response code="400">Se não houver nenhuma parada cadastrada irá retornar código 400 de erro.</response>
        ///  <remarks> 
        /// Exemplo : 
        /// {
        ///   "Name": "MontSerrat 5500",
        ///   "Latitude":-8.814387,
        ///   "Longitude":-63.885770
        /// },
        /// </remarks>  
        [HttpPost]
        public async Task<ActionResult<Parada>> Post([FromServices] ApiDataContext context, [FromBody] Parada model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Paradas.Add(model);
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
        /// Busca todas as Paradas cadastradas no banco.
        /// </summary>
        /// <response code="200">Se houver paradas cadastradas no banco irá retornar uma lista de paradas com código 200.</response>
        /// <response code="404">Caso não tenha irá retornar um código de erro 404.</response>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Parada>>> Get([FromServices] ApiDataContext context)
        {
            if (ModelState.IsValid)
            {
                var paradas = await context.Paradas.ToListAsync();
                if (paradas != null)
                {
                    return Ok(paradas);
                }
            }
            return NotFound();
        }
        /// <summary>
        /// Busca paradas por ID, você deve informar o ID da parada desejada.
        /// </summary>
        /// <response code="200">Caso exista no banco irá retornar a parada encontrada com mesmo ID</response>
        /// <response code="404">Caso não exista nenhuma parada correspondente no banco com mesmo ID, será retornado o código 404.</response>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Parada>>> GetById([FromServices] ApiDataContext context, long id)
        {
            if (ModelState.IsValid)
            {
                var paradas = await context.Paradas.FirstOrDefaultAsync(x => x.Id == id);
                if (paradas != null)
                {
                    return Ok(paradas);
                }
            }
            return NotFound();
        }

        /// <summary>
        /// Atualização de dados da Parada, você deve informar o ID da parada desejada e no corpo da requisição deverá conter os dados a serem alterados.
        /// </summary>
        /// <response code="200">Se for atualizada com sucesso, irá retornar o corpo atualizado.</response>
        /// <response code="400">Se o ID informado for menor que 0, terá um retorno 400.</response>
        /// <response code="404">Se o ID informado não corresponder a nenhuma paradas cadastrada no banco irá ter retorno 404.</response>
        ///  <remarks> 
        /// Exemplo do corpo: 
        /// {
        ///"Name": "Campo Sales 4545",
        ///"Latitude":-8.807555,
        ///"Longitude":-63.888494
        /// },
        /// </remarks>  
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Parada>> Update([FromServices] ApiDataContext context, long id, [FromBody] Parada model)
        {
            if (id > 0)
            {
                var parada = await context.Paradas.FirstOrDefaultAsync(x => x.Id == id);
                if (parada != null)
                {
                    parada.Latitude = model.Latitude;
                    parada.Longitude = model.Longitude;
                    parada.Name = model.Name;
                    context.Update(parada);
                    await context.SaveChangesAsync();
                    return Ok(parada);
                }
                return NotFound();
            }
            return BadRequest();
        }

        /// <summary>
        /// Deleta uma paradas cadastrada no banco pelo ID, você deve utilizar esse método com cuidado!!
        /// </summary>
        /// <response code="200">Se houver alguma parada cadastrada com esse mesmo ID informado ela será removida do banco de dados.</response>
        /// <response code="400">Se o ID informado for menor que 0, terá um retorno 400.</response>
        /// <response code="404">Se o ID informado não corresponder a nenhuma paradas cadastrada no banco irá ter retorno 404.</response>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromServices] ApiDataContext context, long id)
        {
            if (id > 0)
            {
                if (ModelState.IsValid)
                {
                    var parada = await context.Paradas.FirstOrDefaultAsync(x => x.Id == id);
                    if (parada != null)
                    {
                        context.Remove(parada);
                        await context.SaveChangesAsync();
                        return Ok(parada);
                    }
                    return NotFound();
                }
            }
            return BadRequest();
        }
    }
}
