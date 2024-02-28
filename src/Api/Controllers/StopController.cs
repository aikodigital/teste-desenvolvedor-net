using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using Application.Responses;
using Application.Queries.Contracts;
using Application.Requests;
using SharedKernel.Infrastructure.Pagination;
using Application.Commands.Contracts;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopController : CustomController
    {
        protected readonly IStopQueryServiceApplication _queryService;
        protected readonly IStopCommandServiceApplication _commandService;
        public StopController(ILogger<StopController> logger, 
            IStopQueryServiceApplication queryService,
            IStopCommandServiceApplication commandService) : base(logger)
        {
            _queryService = queryService;
            _commandService = commandService;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(PagedResult<StopResponse>), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(List<StopResponse>), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(StopResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateStopRequest request)
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
        [ProducesResponseType(typeof(StopResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] UpdateStopRequest request)
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
        [ProducesResponseType(typeof(StopResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromBody] DeleteStopRequest request)
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
