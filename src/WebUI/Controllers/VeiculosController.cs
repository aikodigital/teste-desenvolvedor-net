using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly string baseUrl;

        public VeiculosController([FromServices] IConfiguration configuration)
        {
            baseUrl = configuration["APIBaseUrl"];
        }

        public async Task<IActionResult> Index()
        {
            var veiculos = await baseUrl.AppendPathSegment("/Veiculos").GetJsonAsync<VeiculoViewModel[]>();

            return View(veiculos);
        }
    }
}