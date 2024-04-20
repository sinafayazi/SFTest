using Communal.Application.Infrastructure.Operations;
using Communal.Application.Models;
using MediatR;

namespace StoreService.Application.Models.Commands.Orders
{
    public class BuyProductCommand : Request, IRequest<OperationResult>
    {
        public int BuyerId { get; set; }
        public int ProductId { get; set; } 
    }
}
