using System.Linq.Expressions;
using StoreService.Domain.Products;

namespace StoreService.Application.Specifications.Products
{
    public class DuplicateProductSpecification : Specification<Product>
    {
        private readonly string _title;
        

        public DuplicateProductSpecification(string title)
        {
            _title = title;
        }

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return product => product.Title.ToLower() == _title.ToLower();
        }
    }
}