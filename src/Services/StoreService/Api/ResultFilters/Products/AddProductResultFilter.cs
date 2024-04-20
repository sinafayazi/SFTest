using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StoreService.Domain.Products;

namespace StoreService.Api.ResultFilters.Products
{
    public class AddProductResultFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result as ObjectResult;

            if (result?.Value is Product value)
                result.Value = new
                {
                    Id = value.Id,
                    Title = value.Title
                };

            await next();
        }
    }
}