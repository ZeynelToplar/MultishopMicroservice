using Multishop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using Multishop.Order.Application.Features.CQRS.Results.AddressResults;
using Multishop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery request)
        {
            var response = await _repository.GetByIdAsync(request.Id);
            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailId = response.OrderDetailId,
                OrderingId = response.OrderingId,
                ProductAmount = response.ProductAmount,
                ProductId = response.ProductId,
                ProductName = response.ProductName,
                ProductPrice = response.ProductPrice,
                ProductTotalPrice = response.ProductTotalPrice
            };
        }
    }
}
