using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ParadasController : Controller
    {
        private readonly string baseUrl;

        public ParadasController([FromServices] IConfiguration configuration)
        {
            baseUrl = configuration["APIBaseUrl"];
        }

        public async Task<IActionResult> Index()
        {
            var paradas = await baseUrl.AppendPathSegment("/Paradas").GetJsonAsync<ParadaViewModel[]>();

            return View(paradas);
        }

        public async Task<IActionResult> Detalhes(long id, string nomeDaParada)
        {
            var detalhesDaParadaViewModel = await baseUrl.AppendPathSegment($"/LinhasPorParada/{id}").GetJsonAsync<LinhaViewModel[]>();

            ViewBag.NomeDaParada = nomeDaParada;

            return View(detalhesDaParadaViewModel);
        }
    }
}