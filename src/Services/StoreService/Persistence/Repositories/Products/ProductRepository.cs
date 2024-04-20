using Microsoft.EntityFrameworkCore;
using StoreService.Application.Interfaces.Repositories;
using StoreService.Domain.Products;

namespace StoreService.Persistence.Repositories.Products
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IQueryable<Product> _queryable;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _queryable = DbContext.Set<Product>();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _queryable.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> GetProductByTitleAsync(string title)
        {
            return await _queryable.FirstOrDefaultAsync(x => x.Title.ToLower() == title.ToLower());
        }
        
    }
}