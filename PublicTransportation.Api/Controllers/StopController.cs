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
        public IActionResult GetAll([FromQuery] StopSearchParameters searchPrameters)
        {
            return Ok(_stopServices.Search(searchPrameters));
        }

        [HttpGet("{id:long}")]
        public IActionResult GetById(long id)
        {
            return Ok(_stopServices.GetById(id));
        }

        [HttpGet("closest/latitude/{latitude:double}/longitude/{longitude:double}")]
        public IActionResult GetClosestStops(double latitude, double longitude)
        {
            return Ok(_stopServices.GetClosestStops(latitude, longitude));
        }

        [HttpGet("{id:long}/lines")]
        public IActionResult GetByIdWithLines(long id)
        {
            return Ok(_stopServices.GetByIdWithLines(id));
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateStopDTO dto)
        {
            _stopServices.Create(dto);
            return new ObjectResult(dto)
            {
                StatusCode = StatusCodes.Status201Created
            };
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
