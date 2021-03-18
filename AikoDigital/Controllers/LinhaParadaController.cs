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
    /// Controller de Linha-Parada, Essa controller foi criada como intermédio entre as duas classes
    /// para resolver um problema de muitos para muitos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class LinhaParadaController : ControllerBase
    {

        /// <summary>
        /// Para Adicionar uma ligação de uma linha a uma parada você deve informar o ID da parada e no corpo da requisição passar as linhas que deseja vincular.
        /// </summary>
        /// <response code="200">Caso seja vinculadas com sucesso, irá ter um retorno 200.</response>
        /// <response code="400">Se não for possivel criar a vinculação irá ter um retorno 400.</response>
        ///  /// <remarks> 
        /// Exemplo do corpo da requisição : 
        /// {
        /// URL: Requisição "http://localhost:55011/api/linhaparada/1/parada"
        ///   Corpo da Requisição ----> [2,1]
        /// Podemos ver aqui que estou informando a linha 2 e a linha 1 para serem vinculadas a parada de ID 1
        /// }
        /// </remarks>
        [HttpPost("{paradaId}/parada")]
        public async Task<IActionResult> AddLinhaParada([FromServices] ApiDataContext context, long ParadaId, [FromBody] params long[] linhas)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var parada = await context.Paradas.Include(x => x.LinhaParadas).FirstOrDefaultAsync(x => x.Id == ParadaId);
                    if (!parada.LinhaParadas.Any())
                    {
                        parada.LinhaParadas = new List<LinhaParada>();
                    }
                    foreach (var linhaId in linhas)
                    {
                        var linhaParadamodel = new LinhaParada();
                        var linha = await context.Linhas.FindAsync(linhaId);
                        linhaParadamodel.LinhaId = linha.Id;
                        linhaParadamodel.ParadaId = ParadaId;
                        parada.LinhaParadas.Add(linhaParadamodel);
                    }

                    context.Update(parada);
                    await context.SaveChangesAsync();
                    return Ok();
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
        /// Consulta de linhas vinculadas a uma parada, você deve informar um ID e será buscado a lista de linhas vinculadas 
        /// a essa parada ID.
        /// </summary>
        /// <response code="200">Caso a parada informada tiver uma linha vinculada será retornada a lista de linhas.</response>
        /// <response code="400">Caso Parada id seja menor que 0, deverá ser exibido o código 400.</response>
        /// <response code="404">Caso não tenha irá apena retornar um código 404.</response>
        [HttpGet]
        [Route("{ParadaId}")]
        public async Task<ActionResult<List<Linha>>> getLinhaByParadaId([FromServices] ApiDataContext context, long ParadaId)
        {
            if (ParadaId > 0)
            {
                var listaLinhasParada = await context.LinhaParadas.Where(x => x.ParadaId == ParadaId).ToListAsync();
                if (listaLinhasParada.Any())
                {
                    var listaDeLinhas = new List<Linha>();
                    foreach (var item in listaLinhasParada)
                    {
                        var linha = await context.Linhas.Where(x => x.Id == item.LinhaId).FirstOrDefaultAsync();
                        linha.LinhaParadas = null;
                        listaDeLinhas.Add(linha);
                    }
                    return Ok(listaDeLinhas);
                }
                return NotFound();
            }
            return BadRequest();
        }
    }
}
