using Microsoft.AspNetCore.Mvc;
using PublicTransportation.Application.UseCases.Vehicles;
using PublicTransportation.Domain.DTO.Create;
using PublicTransportation.Domain.DTO.Edit;
using PublicTransportation.Domain.Utils;

namespace PublicTransportation.Api.Controllers
{
    public class VehicleController : BaseController
    {
        private readonly VehicleServices _vehicleServices;

        public VehicleController(VehicleServices vehicleServices)
        {
            _vehicleServices = vehicleServices;
        }

        
        [HttpGet]
        public IActionResult GetById([FromQuery] VehicleSearchParameters searchPrameters)
        {
            return Ok(_vehicleServices.Search(searchPrameters));
        }

        [HttpGet("{id:long}")]
        public IActionResult GetById(long id)
        {
            return Ok(_vehicleServices.GetById(id));
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateVehicleDTO dto)
        {
            _vehicleServices.Create(dto);
            return Ok();
        }

        [HttpPut("{id:long}")]
        public IActionResult Update([FromBody] UpdateVehicleDTO dto, long id)
        {
            _vehicleServices.Update(dto, id);
            return Ok();
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            _vehicleServices.Delete(id);
            return NoContent();
        }

        [HttpPost("{vehicleId:long}/position")]
        public IActionResult CreateVehiclePosition([FromBody] CreateVehiclePositionDTO dto, long vehicleId)
        {
            _vehicleServices.CreateVehiclePosition(dto, vehicleId);
            return Ok();
        }

        [HttpPut("{vehicleId:long}/position")]
        public IActionResult UpdateVehiclePosition([FromBody] UpdateVehiclePositionDTO dto, long vehicleId)
        {
            _vehicleServices.UpdateVehiclePosition(dto, vehicleId);
            return Ok();
        }

        [HttpDelete("{vehicleId:long}/position/delete")]
        public IActionResult DeleteVehiclePosition(long vehicleId)
        {
            _vehicleServices.DeleteVehiclePosition(vehicleId);
            return NoContent();
        }
    }
}
