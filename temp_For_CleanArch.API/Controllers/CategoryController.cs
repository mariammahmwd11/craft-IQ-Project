using CraftIQ.Application.Features.categorys.Command.Createcategory;
using CraftIQ.Application.Features.categorys.Command.Deletecategory;
using CraftIQ.Application.Features.categorys.Command.Updatecategory;
using CraftIQ.Application.Features.categorys.Query.GetAllcategory;
using CraftIQ.Application.Features.categorys.Query.GetcategoryById;
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
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public IActionResult GatAllCategories()
        {
            var query = new GetAllcategoryQuery();
            var result = mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var query = new GetcategoryByIdQuery(id);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreatecategoryCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, UpdatecategoryCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var result = mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id, DeletecategoryCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            var result = mediator.Send(command);
            return Ok(result);
        }
    }
}
