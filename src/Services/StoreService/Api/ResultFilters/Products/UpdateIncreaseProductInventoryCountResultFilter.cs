using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StoreService.Domain.Products;

namespace StoreService.Api.ResultFilters.Products
{
    public class UpdateIncreaseProductInventoryCountResultFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result as ObjectResult;

            if (result?.Value is Product value)
                result.Value = new
                {
                    Id = value.Id,
                    Title = value.Title,
                    NewProductInventoryCount = value.InventoryCount,
                    UpdatedAt = value.UpdatedAt
                };

            await next();
        }
    }
}
