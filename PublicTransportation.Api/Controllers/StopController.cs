using Microsoft.AspNetCore.Mvc;
using PublicTransportation.Application.UseCases.Stops;
using PublicTransportation.Domain.DTO.Create;
using PublicTransportation.Domain.DTO.Edit;
using PublicTransportation.Domain.Utils;

namespace PublicTransportation.Api.Controllers
{
    public class StopController : BaseController
    {
        private readonly StopServices _stopServices;

        public StopController(StopServices stopServices)
        {
            _stopServices = stopServices;
        }

        
        [HttpGet]
        public IActionResult GetById([FromQuery] StopSearchParameters searchPrameters)
        {
            return Ok(_stopServices.Search(searchPrameters));
        }

        [HttpGet("{id:long}")]
        public IActionResult GetById(long id)
        {
            return Ok(_stopServices.GetById(id));
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateStopDTO dto)
        {
            _stopServices.Create(dto);
            return Ok();
        }

        [HttpPut("{id:long}")]
        public IActionResult Update([FromBody] UpdateStopDTO dto, long id)
        {
            _stopServices.Update(dto, id);
            return Ok();
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            _stopServices.Delete(id);
            return NoContent();
        }
    }
}
