using StoreService.Application.Helpers;
using StoreService.Application.Models.Responses.Products;
using Product = StoreService.Domain.Products.Product;

namespace StoreService.Application.Mappers
{
    public static class ProductMapper
    {
        public static ProductResponse MapToProductResponse(this Product product)
        {
            return new ProductResponse
            {
                Id = product.Id,
                Title = product.Title,
                InventoryCount = product.InventoryCount,
                OriginalPrice = product.Price,
                DiscountInPercent = product.Discount,
                EndPrice = product.GetEndPrice(),

                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
            };
        }

        public static IEnumerable<ProductResponse> MapToUserResponses(this IEnumerable<Product> products)
        {
            foreach (var product in products)
                yield return product.MapToProductResponse();
        }
    }
}