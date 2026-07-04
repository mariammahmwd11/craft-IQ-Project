using CraftIQ.Application.Features.Orders.Command.CreateOrder;
using CraftIQ.Application.Features.Orders.Command.DeleteOrder;
using CraftIQ.Application.Features.Orders.Command.UpdateOrder;
using CraftIQ.Application.Features.Orders.Query.GetAllOrder;
using CraftIQ.Application.Features.Orders.Query.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ_Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public IActionResult GatAllOrders()
        {
            var query = new GetAllOrderQuery();
            var result = mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var query = new GetOrderByIdQuery(id);
            var result =await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, UpdateOrderCommand command)
        {
            if (id != command.OrderId)
                return BadRequest();

            var result =mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id,DeleteOrderCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            var result =mediator.Send(command);
            return Ok(result);
        }
    }
}
