
using CraftIQ.Application.Features.Inventorys.Command.CreateInventory;
using CraftIQ.Application.Features.Inventorys.Command.DeleteInventory;
using CraftIQ.Application.Features.Inventorys.Command.UpdateInventory;
using CraftIQ.Application.Features.Inventorys.Query.GetAllInventory;
using CraftIQ.Application.Features.Inventorys.Query.GetInventoryById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ_Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public InventoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public IActionResult GatAllInventories()
        {
            var query = new GetAllInventoryQuery();
            var result = mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventoryById(Guid id)
        {
            var query = new GetInventoryByIdQuery(id);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Createinventory(CreateInventoryCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Updateinventory(Guid id, UpdateInventoryCommand command)
        {
            if (id != command.InventoryId)
                return BadRequest();

            var result = mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(Guid id, DeleteInventoryCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            var result = mediator.Send(command);
            return Ok(result);
        }
    }
}
