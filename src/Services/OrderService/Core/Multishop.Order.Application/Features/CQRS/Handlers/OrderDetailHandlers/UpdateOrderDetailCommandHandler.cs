using Multishop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var response = await _repository.GetByIdAsync(command.OrderDetailId);
            if (response != null)
            {
                response.OrderingId = command.OrderingId;
                response.ProductPrice = command.ProductPrice;
                response.ProductName = command.ProductName;
                response.ProductPrice = command.ProductPrice;
                response.ProductAmount = command.ProductAmount;
                response.ProductTotalPrice = command.ProductTotalPrice;
                await _repository.UpdateAsync(response);
            }
        }
    }
}
