using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class CustomController : ControllerBase
    {
        private readonly ILogger<CustomController> _logger;
        protected ICollection<string> Errors = new List<string>();

        public CustomController(
            ILogger<CustomController> logger)
        {
            _logger = logger;
        }

        protected ActionResult CustomResponse<T>(T result)
        {
            return Ok(result);
        }

        protected ActionResult CustomResponseException(Exception exception)
        {
            return BadRequest(new Dictionary<string, object>
                {
                    { "success", false },
                    { "data", exception.Message }
                });
        }

        protected void LoggerError(Exception logger, string mensagem)
        {
            _logger.LogError(logger, mensagem);
        }

        protected void LoggerInformation(object objects = null)
        {
            _logger.LogInformation($"{objects}");
        }
    }
}
