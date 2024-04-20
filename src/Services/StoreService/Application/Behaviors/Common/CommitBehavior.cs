using Communal.Application.Infrastructure.Operations;
using StoreService.Application.Interfaces;
using MediatR;

namespace StoreService.Application.Behaviors.Common
{
    public class CommitBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommitBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<OperationResult> next)
        {
            var response = await next();

            if (response.Succeeded && response.IsPersistable)
                return new OperationResult(response, await _unitOfWork.CommitAsync());

            return response;
        }
        
    }
}