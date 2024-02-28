using Application.Commands;
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
using Application.Commands.Contracts;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : CustomController
    {
        protected readonly IVehicleQueryServiceApplication _queryService;
        protected readonly IVehicleCommandServiceApplication _commandService;
        public VehiclesController(ILogger<VehiclesController> logger,
            IVehicleQueryServiceApplication queryService,
            IVehicleCommandServiceApplication commandService) : base(logger)
        {
            _queryService = queryService;
            _commandService = commandService;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(PagedResult<VehicleResponse>), StatusCodes.Status200OK)]
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

        [HttpGet("{vehicleId:long}/Position")]
        [ProducesResponseType(typeof(VehicleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetVehiclePosition(long vehicleId)
        {
            try
            {
                var result = await _queryService.GetVehiclePosition(vehicleId);
                return CustomResponse(result);
            }
            catch (Exception error)
            {
                LoggerError(error, "GetVehiclePosition");
                return CustomResponseException(error);
            }
        }
        
        [HttpGet("{lineId:long}/VehiclesAndLines")]
        [ProducesResponseType(typeof(VehicleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> VehiclesAndLines(long lineId)
        {
            try
            {
                var result = await _queryService.VehiclesAndLines(lineId);
                return CustomResponse(result);
            }
            catch (Exception error)
            {
                LoggerError(error, "VehiclesAndLines");
                return CustomResponseException(error);
            }
        }


        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(List<VehicleResponse>), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(VehicleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateVehicleRequest request)
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
        [ProducesResponseType(typeof(VehicleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] UpdateVehicleRequest request)
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
        [ProducesResponseType(typeof(VehicleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromBody] DeleteVehicleRequest request)
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
