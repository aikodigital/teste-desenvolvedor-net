using ApiTransporte.Api.BusStops.Services;
using ApiTransporte.Core.Exceptions;
using ApiTransporte.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ApiTransporte.Api.Controllers
{
    /// <summary>
    /// BusStopController
    /// </summary>
    [Route("api/busStop")]
    [ApiController]
    public class BusStopController : ControllerBase
    {
        private readonly IBusStopService _busStopService;
        private readonly BusStopService _busStop;

        public BusStopController(IBusStopService busStopService, BusStopService busStop)
        {
            _busStopService = busStopService;
            _busStop = busStop;
        }

        [HttpGet]
        public IActionResult FindAll() 
        {
            return Ok(_busStopService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById([FromRoute] long id)
        {
            try
            {
                return Ok(_busStopService.FindById(id));
            }
            catch (CustomNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] BusStop busStop)
        {
            var result = _busStopService.Create(busStop);
            var jsonResult = JsonSerializer.Serialize(result, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return new JsonResult(jsonResult)
            {
                StatusCode = (int)HttpStatusCode.Created
            };
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById([FromRoute] long id, [FromBody] BusStop busStop)
        {
            try
            {
                return Ok(_busStopService.UpdateById(id, busStop));
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
                _busStopService.DeleteById(id);
                return NoContent();
            }
            catch (CustomNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //[HttpGet("{id}/lines")]
        //public IActionResult GetLinesForBusStop([FromRoute] long id)
        //{
        //    try
        //    {
        //        return Ok(_busStopService.GetLinesForBusStop(id));
        //    }
        //    catch (CustomNotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}
    }
}
