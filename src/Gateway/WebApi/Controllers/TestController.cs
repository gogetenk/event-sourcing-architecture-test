using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace YtDeveloppement.EventSourcing.Gateway.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IMediator _mediator;

        public TestController(ILogger<TestController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
            //var query = new GetAllCustomersQuery();
            //var result = _mediator.Send(query);
            //return Ok(result);
        }
    }
}
