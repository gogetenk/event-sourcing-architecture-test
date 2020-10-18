using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YtDeveloppement.EventSourcing.Microservices.Orders.Application.Commands;
using YtDeveloppement.EventSourcing.Microservices.Orders.Application.Queries;
using YtDeveloppement.EventSourcing.Microservices.Orders.Domain.Dtos;

namespace YtDeveloppement.EventSourcing.Microservices.Orders.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IMediator _mediator;

        public OrdersController(ILogger<OrdersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllOrdersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(string id)
        {
            var query = new GetOrderByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderDto order)
        {
            var query = new CreateOrderCommand(order);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
