using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class LinhasController : Controller
    {
        private readonly string baseUrl;

        public LinhasController([FromServices]IConfiguration configuration)
        {
            baseUrl = configuration["APIBaseUrl"];
        }

        public async Task<IActionResult> Index()
        {
            var linhas = await baseUrl.AppendPathSegment("/Linhas").GetJsonAsync<LinhaViewModel[]>();

            return View(linhas);
        }

        public async Task<IActionResult> Detalhes(long id)
        {
            var detalhesDaLinhasViewModel = await baseUrl.AppendPathSegment($"/Linhas/{id}").GetJsonAsync<DetalhesDaLinhasViewModel>();

            return View(detalhesDaLinhasViewModel);
        }
    }
}