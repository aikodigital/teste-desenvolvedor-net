using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        [HttpGet]
        public async Task Get()
        {
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task Get(long id)
        {
        }

        [HttpPost]
        [Route("[action]/{id:long}")]
        public async Task Post(long id)
        {
        }

        [HttpPut]
        public async Task Put()
        {
        }

        [HttpDelete]
        [Route("[action]/{id:long}")]
        public async Task Delete(long id)
        {
        }
    }
}