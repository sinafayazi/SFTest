using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StoreService.Application.Models.Responses.Products;

namespace StoreService.Api.ResultFilters.Products
{
    public class GetProductResultFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result as ObjectResult;

            if (result?.Value is ProductResponse value)
                result.Value = new
                {
                    value.Id,
                    value.Title,
                    value.InventoryCount,
                    value.OriginalPrice,
                    value.DiscountInPercent,
                    value.EndPrice,
                    value.CreatedAt,
                    value.UpdatedAt
                };

            await next();
        }
    }
}