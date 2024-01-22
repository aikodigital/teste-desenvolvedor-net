using ApiTransporte.Api.VehiclePositions.Services;
using ApiTransporte.Core.Exceptions;
using ApiTransporte.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiTransporte.Api.Controllers
{
    /// <summary>
    /// VehiclePositionController
    /// </summary>
    [ApiController]
    [Route("/api/vehiclePositions")]
    public class VehiclePositionController : ControllerBase
    {
        private readonly IVehiclePositionService _vehiclePositionService;

        public VehiclePositionController(IVehiclePositionService vehiclePositionService)
        {
            _vehiclePositionService = vehiclePositionService;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_vehiclePositionService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById([FromRoute] long id)
        {
            try
            {
                return Ok(_vehiclePositionService.FindById(id));
            }
            catch (CustomNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] VehiclePosition vehiclePosition)
        {
            var body = _vehiclePositionService.Create(vehiclePosition);
            return CreatedAtAction(nameof(FindById), new { Id = vehiclePosition.Id }, body);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById([FromRoute] long id, [FromBody] VehiclePosition vehiclePosition)
        {
            try
            {
                return Ok(_vehiclePositionService.UpdateById(id, vehiclePosition));
            }
            catch (CustomNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById([FromRoute] long id)
        {
            try
            {
                _vehiclePositionService.DeleteById(id);
                return NoContent();
            }
            catch (CustomNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
