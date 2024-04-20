using Communal.Application.Infrastructure.Operations;
using Communal.Application.Models;
using MediatR;

namespace StoreService.Application.Models.Commands.Products
{
    public class UpdateIncreaseProductInventoryCountCommand : Request, IRequest<OperationResult>
    {
        public int ProductId { get; set; }
        public uint IncreaseAmount { get; set; }
    }
}
