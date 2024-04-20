using Communal.Api.Extensions.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreService.Api.Models.Requests.Products;
using StoreService.Api.ResultFilters.Products;
using StoreService.Application.Models.Commands.Orders;
using StoreService.Application.Models.Queries.Products;

namespace StoreService.Api.Controllers
{
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Detail
        [HttpGet(Routes.Store + "{id}")]
        [GetProductResultFilter]
        public async Task<IActionResult> GetProductDetail([FromRoute] int id)
        {

            // Operation
            var operation = await _mediator.Send(new GetProductQuery
            {
                ProductId = id
            });

            return this.ReturnResponse(operation);
        }

        [HttpPatch(Routes.Store + "{id}")]
        [UpdateProductResultFilter]
        public async Task<IActionResult> BuyProduct([FromRoute] int id,[FromBody] BuyProductRequest request)
        {
            // Operation
         var operation = await _mediator.Send(new BuyProductCommand
            {
                BuyerId = request.BuyerId,
                ProductId = id
            });

            return this.ReturnResponse(operation);
        }
        
    }
}