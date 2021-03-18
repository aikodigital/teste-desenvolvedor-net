using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AikoDigital.DataContext;
using AikoDigital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AikoDigital.Controllers
{
    /// <summary>
    /// Controller de Linhas, onde fica todo o processamento das requisições relacionada a Linhas.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class LinhaController : ControllerBase
    {
        /// <summary>
        /// Cadastra uma linha
        /// </summary>
        /// <returns>Retorna o objeto que foi criado.</returns>
        /// <response code="200">Se a linha for cadastrada com sucesso terá retorno 200</response>
        /// <response code="400">Se o retorno foi 400 é porque o conteudo não atendeu os parametros da requisição</response>
        /// <remarks> 
        /// Exemplo : '
        /// {
        ///    "Name": "Mont Serrat"
        /// }
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Linha>> Post([FromServices] ApiDataContext context, [FromBody] Linha model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Linhas.Add(model);
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
        /// Busca Todas as Linhas Cadastradas 
        /// </summary>
        /// <response code="200">Se houver linhas cadastradas no banco de dados irá retornar uma lista com todas elas.</response>
        /// <response code="400">Se não houver nenhuma linha cadastrada irá retornar código 400 de erro.</response>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Linha>>> Get([FromServices] ApiDataContext context)
        {
            if (ModelState.IsValid)
            {
                var paradas = await context.Linhas.ToListAsync();
                if (paradas != null)
                {
                    return Ok(paradas);
                }
            }
            return NotFound();
        }

        /// <summary>
        /// Recebe um ID e retorna uma linha que tenha esse ID.
        /// </summary>
        /// <response code="200">Se houver alguma linha cadastrada com esse mesmo ID será retornada com código 200.</response>
        /// <response code="400">Se não houver nenhuma linha cadastrada irá retornar código 400 de erro.</response>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Linha>> GetById([FromServices] ApiDataContext context, long id)
        {
            if (ModelState.IsValid)
            {
                var linha = await context.Linhas.FirstOrDefaultAsync(x => x.Id == id);
                if (linha != null)
                {
                    return Ok(linha);
                }
            }
            return NotFound();
        }
        /// <summary>
        /// Você informa o ID de uma linha no qual você deseja atualizar, passando a sua alteração no corpo da requisição.
        /// </summary>
        /// <response code="200">Se a atualização for feita com sucesso, irá retornar código 200 mostrando o objeto alterado.</response>
        /// <response code="400">Caso não seja possivel encontrar a linha com o ID informado será retornado um código 400.</response>
        ///  <remarks> 
        /// Exemplo do corpo para Alteração : 
        /// {
        ///   "Jorge Teixeira"
        /// }
        /// </remarks>
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Linha>> Update([FromServices] ApiDataContext context, long id, [FromBody] string descricao)
        {
            var linha = await context.Linhas.FirstOrDefaultAsync(x => x.Id == id);
            if (linha != null)
            {
                linha.Name = descricao;
                context.Update(linha);
                await context.SaveChangesAsync();
                return Ok(linha);
            }
            return BadRequest();
        }
        /// <summary>
        ///Deletar Linha, para deletar uma linha você deve informar o ID da linha desejada, Utilize com cuidado!!.
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Linha>> Delete([FromServices] ApiDataContext context, long id)
        {
            if (ModelState.IsValid)
            {
                var linha = await context.Linhas.FirstOrDefaultAsync(x => x.Id == id);
                context.Remove(linha);
                await context.SaveChangesAsync();
                return Ok(linha);
            }
            return BadRequest();
        }
    }
}
