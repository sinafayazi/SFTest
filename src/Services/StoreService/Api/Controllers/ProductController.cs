using Communal.Api.Extensions.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreService.Api.Models.Requests.Products;
using StoreService.Api.ResultFilters.Products;
using StoreService.Application.Models.Commands.Products;

namespace StoreService.Api.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Add Product
        [HttpPost(Routes.Product)]
        [AddProductResultFilter]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            // Operation
            var operation = await _mediator.Send(new AddProductCommand
            {
                Title = request.Title,
                Price = request.Price,
                InventoryCount = request.InventoryCount,
                Discount = request.Discount
            });

            return this.ReturnResponse(operation);
        }

       

        [HttpPatch(Routes.Product + "{id}")]
        [UpdateIncreaseProductInventoryCountResultFilter]
        public async Task<IActionResult> UpdateIncreaseProductInventoryCount([FromRoute] int id, [FromBody] UpdateIncreaseProductInventoryCountRequest request)
        {
            // Operation
            var operation = await _mediator.Send(new UpdateIncreaseProductInventoryCountCommand
            {
                ProductId = id,
               IncreaseAmount = request.IncreaseAmount
            });

            return this.ReturnResponse(operation);
        }
        
    }
}