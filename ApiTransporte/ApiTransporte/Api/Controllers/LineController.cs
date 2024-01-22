using ApiTransporte.Api.Lines.Services;
using ApiTransporte.Core.Exceptions;
using ApiTransporte.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ApiTransporte.Api.Controllers
{
    /// <summary>
    /// LineController
    /// </summary>
    [ApiController]
    [Route("/api/lines")]
    public class LineController : ControllerBase
    {
      private readonly ILineService _lineService;

        public LineController(ILineService lineService)
        {
            _lineService = lineService;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_lineService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById([FromRoute] long id)
        {
            try
            {
                return Ok(_lineService.FindById(id));
            }
            catch (CustomNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Line line)
        {
            var result = _lineService.Create(line);
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
        public IActionResult UpdateById([FromRoute] long id, [FromBody] Line line)
        {
            try
            {
                return Ok(_lineService.UpdateById(id, line));
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
                _lineService.DeleteById(id);
                return NoContent();
            }
            catch (CustomNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
