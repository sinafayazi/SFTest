using Communal.Application.Infrastructure.Operations;
using Communal.Application.Models;
using MediatR;

namespace StoreService.Application.Models.Queries.Products
{
    public class GetProductQuery : Request, IRequest<OperationResult>
    {
        public int ProductId { get; set; }
    }
}