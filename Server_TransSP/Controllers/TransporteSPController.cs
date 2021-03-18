using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_TransSP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransporteSPController : ControllerBase
    {
        private readonly ILogger<TransporteSPController> _logger;

        public TransporteSPController(ILogger<TransporteSPController> logger)
        {
            _logger = logger;
        }


        
    }
}
