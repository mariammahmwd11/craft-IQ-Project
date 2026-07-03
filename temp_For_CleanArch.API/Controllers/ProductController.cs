using CraftIQ.Application.Features.Products.Command.CreateProduct;
using CraftIQ.Application.Features.Products .Command.DeleteProduct;
using CraftIQ.Application.Features.Products.Command.UpdateProduct;
using CraftIQ.Application.Features.Products.Query.GetAllProduct;
using CraftIQ.Application.Features.Products.Query.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductsQuery();

            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            var query = new GetProductByIdQuery(productId);

            var result = await mediator.Send(query);

            return Ok(result);
        }


        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }


        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(
        Guid productId,
        UpdateProductCommand command)
        {
            if (productId != command.ProductId)
                return BadRequest();

            await mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            await mediator.Send(new DeleteProductCommand(productId));

            return NoContent();
        }
    }
}
