using Multishop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var response = await _repository.GetAllAsync();
            return response.Select(r => new GetOrderDetailQueryResult
            {
                OrderDetailId = r.OrderDetailId,
                ProductAmount = r.ProductAmount,
                ProductName = r.ProductName,
                OrderingId = r.OrderingId,
                ProductId = r.ProductId,
                ProductPrice = r.ProductPrice,
                ProductTotalPrice = r.ProductTotalPrice,
            }).ToList();
        }
    }
}
