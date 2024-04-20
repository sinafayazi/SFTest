using Communal.Application.Infrastructure.Operations;
using Communal.Application.Models;
using MediatR;

namespace StoreService.Application.Models.Commands.Products
{
    public class AddProductCommand : Request, IRequest<OperationResult>
    {
        public string Title { get; set; }
        public uint InventoryCount { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
    }
}
