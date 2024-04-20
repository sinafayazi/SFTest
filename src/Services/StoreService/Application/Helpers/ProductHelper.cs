using StoreService.Application.Models.Commands.Products;
using StoreService.Domain.Products;

namespace StoreService.Application.Helpers
{
    public static class ProductHelper
    {
        public static Product CreateProduct(AddProductCommand command) => new Product()
        {
            Title = command.Title,
            InventoryCount = command.InventoryCount,
            Price = command.Price,
            Discount = command.Discount,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        public static double GetEndPrice(this Product product) => product.Price - product.Price * product.Discount / 100;
    }
}