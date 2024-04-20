using Communal.Application.Infrastructure.Pagination;

namespace StoreService.Application.Models.Responses.Products
{
    public class ProductFilter : PaginationFilter
    {
        protected ProductFilter(int page, int pageSize) : base(page, pageSize)
        {
        }
        
    }
}