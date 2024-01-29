using Microsoft.AspNetCore.Mvc;
using PublicTransportation.Application.UseCases.Lines;
using PublicTransportation.Application.UseCases.Vehicles;
using PublicTransportation.Domain.DTO.Create;
using PublicTransportation.Domain.DTO.Edit;
using PublicTransportation.Domain.Entities;
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
        public IActionResult GetAll([FromQuery] LineSearchParameters searchPrameters)
        {
            return Ok(_lineServices.Search(searchPrameters));
        }

        [HttpGet("{id:long}")]
        public IActionResult GetById(long id)
        {
            return Ok(_lineServices.GetById(id));
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateLineDTO dto)
        {
            _lineServices.Create(dto);
            return new ObjectResult(dto)
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        [HttpPut("{id:long}")]
        public IActionResult Update([FromBody] UpdateLineDTO dto, long id)
        {
            _lineServices.Update(dto, id);
            return Ok();
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            _lineServices.Delete(id);
            return NoContent();
        }

        [HttpDelete("{lineId:long}/remove_stop/{stopId:long}")]
        public IActionResult RemoveStop(long lineId, long stopId)
        {
            _lineServices.RemoveStop(lineId, stopId);
            return NoContent();
        }

        [HttpPost("{id:long}/add_stops")]
        public IActionResult AddStop([FromBody] ICollection<CreateLineStopDTO> dto, long id)
        {
            _lineServices.AddStops(id, dto);
            return NoContent();
        }

        [HttpGet("{id:long}/vehicles")]
        public IActionResult GetByIdWithVehicles(long id)
        {
            return Ok(_lineServices.GetByIdWithVehicles(id));
        }
    }
}
