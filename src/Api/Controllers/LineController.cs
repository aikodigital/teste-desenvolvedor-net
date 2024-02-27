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
using Domain.Entities;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineController : CustomController
    {
        protected readonly ILineQueryServiceApplication _queryService;
        protected readonly ILineCommandServiceApplication _commandService;
        public LineController(ILogger<LineController> logger,
            ILineQueryServiceApplication queryService,
            ILineCommandServiceApplication commandService) : base(logger)
        {
            _queryService = queryService;
            _commandService = commandService;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(PagedResult<LineResponse>), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(List<LineResponse>), StatusCodes.Status200OK)]
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
        
        [HttpGet("{id:long}/LineAndStop")]
        [ProducesResponseType(typeof(List<LineResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LineAndStop(long id)
        {
            try
            {
                var result = await _queryService.LineAndStop(id);
                return CustomResponse(result);
            }
            catch (Exception error)
            {
                LoggerError(error, "LineAndStop");
                return CustomResponseException(error);
            }
        }

        [HttpPost()]
        [ProducesResponseType(typeof(LineResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateLineRequest request)
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
        [ProducesResponseType(typeof(LineResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update([FromBody] UpdateLineRequest request)
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
        [ProducesResponseType(typeof(LineResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete([FromBody] DeleteLineRequest request)
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
