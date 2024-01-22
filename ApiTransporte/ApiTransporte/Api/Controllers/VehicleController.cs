using ApiTransporte.Api.Vehicles.Services;
using ApiTransporte.Core.Exceptions;
using ApiTransporte.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ApiTransporte.Api.Controllers
{
    /// <summary>
    /// VehicleController
    /// </summary>
    [ApiController]
    [Route("/api/vehicles")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly VehicleService _vehicle;

        public VehicleController(IVehicleService vehicleService, VehicleService vehicle)
        {
            _vehicleService = vehicleService;
            _vehicle = vehicle;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_vehicleService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById([FromRoute] long id)
        {
            try
            {
                return Ok(_vehicleService.FindById(id));
            }
            catch (CustomNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Vehicle vehicle)
        {
            var createdVehicle = _vehicleService.Create(vehicle);
            return CreatedAtAction(nameof(FindById), new { id = createdVehicle.Id }, createdVehicle);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById([FromRoute] long id, [FromBody] Vehicle vehicle)
        {
            try
            {
                return Ok(_vehicleService.UpdateById(id, vehicle));
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
                _vehicleService.DeleteById(id);
                return NoContent();
            }
            catch (CustomNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("byLine/{lineId}")]
        public IActionResult GetVehiclesByLine([FromRoute] long lineId)
        {
            try
            {
                return Ok(_vehicle.GetVehiclesByLineId(lineId));
            }
            catch (CustomNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
