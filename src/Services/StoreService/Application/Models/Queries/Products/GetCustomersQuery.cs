using Communal.Application.Infrastructure.Operations;
using Communal.Application.Models;
using MediatR;
using StoreService.Application.Models.Responses.Products;

namespace StoreService.Application.Models.Queries.Products
{
    public class GetUsersQuery : Request, IRequest<OperationResult>
    {
        public ProductFilter Filter { get; set; }
    }
}