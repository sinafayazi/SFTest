using StoreService.Domain.Products;

namespace StoreService.Application.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> GetProductByTitleAsync(string title);
    }
}