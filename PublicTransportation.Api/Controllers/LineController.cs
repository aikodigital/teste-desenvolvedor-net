using Microsoft.AspNetCore.Mvc;
using PublicTransportation.Application.UseCases.Lines;
using PublicTransportation.Domain.DTO.Create;
using PublicTransportation.Domain.DTO.Edit;
using PublicTransportation.Domain.Utils;

namespace PublicTransportation.Api.Controllers
{
    public class LineController : BaseController
    {
        private readonly LineServices _lineServices;

        public LineController(LineServices lineServices)
        {
            _lineServices = lineServices;
        }

        
        [HttpGet]
        public IActionResult GetById([FromQuery] LineSearchParameters searchPrameters)
        {
            return Ok(_lineServices.Search(searchPrameters));
        }

        [HttpGet("{id:long}")]
        public IActionResult GetById(long id)
        {
            return Ok(_lineServices.GetById(id));
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateLineDTO request)
        {
            _lineServices.Create(request);
            return Ok();
        }

        [HttpPut("{id:long}")]
        public IActionResult Update([FromBody] UpdateLineDTO request, long id)
        {
            _lineServices.Update(request, id);
            return Ok();
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            _lineServices.Delete(id);
            return NoContent();
        }
    }
}
