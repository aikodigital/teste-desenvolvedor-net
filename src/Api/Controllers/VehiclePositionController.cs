using Application.Commands.Contracts;
using Application.Queries.Contracts;
using Application.Requests;
using Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclePositionController : CustomController
    {
        protected readonly IVehiclePositionQueryServiceApplication _queryService;
        protected readonly IVehiclePositionCommandServiceApplication _commandService;
        public VehiclePositionController(ILogger<VehiclePositionController> logger,
            IVehiclePositionQueryServiceApplication queryService,
            IVehiclePositionCommandServiceApplication commandService) : base(logger)
        {
            _queryService = queryService;
            _commandService = commandService;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(PagedResult<VehiclePositionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] FilterPaged filter)
        {
            try
            {
                var result = await _queryService.GetAll(filter);
                return CustomResponse(result);
            }
            catch (Exception error)
            {
                LoggerError(error, "GetAll");
                return CustomResponseException(error);
            }
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(List<VehiclePositionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _queryService.FindById(id);
                return CustomResponse(result);
            }
            catch (Exception error)
            {
                LoggerError(error, "GetById");
                return CustomResponseException(error);
            }
        }

        [HttpPost()]
        [ProducesResponseType(typeof(VehiclePositionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateVehiclePositionRequest request)
        {
            try
            {
                if (request is null)
                    throw new Exception("Invalid object");
                var result = await _commandService.Create(request);
                return CustomResponse(result);
            }
            catch (Exception error)
            {
                LoggerError(error, "Create");
                return CustomResponseException(error);
            }
        }

        [HttpPut()]
        [ProducesResponseType(typeof(VehiclePositionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update([FromBody] UpdateVehiclePositionRequest request)
        {
            try
            {
                if (request is null)
                    throw new Exception("Invalid object");
                var result = await _commandService.Update(request);
                return CustomResponse(result);
            }
            catch (Exception error)
            {
                LoggerError(error, "Update");
                return CustomResponseException(error);
            }
        }

        [HttpDelete()]
        [ProducesResponseType(typeof(VehiclePositionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete([FromBody] DeleteVehiclePositionRequest request)
        {
            try
            {
                if (request is null)
                    throw new Exception("Invalid object");
                var result = await _commandService.Delete(request);
                return CustomResponse(result);
            }
            catch (Exception error)
            {
                LoggerError(error, "Delete");
                return CustomResponseException(error);
            }
        }
    }
}
