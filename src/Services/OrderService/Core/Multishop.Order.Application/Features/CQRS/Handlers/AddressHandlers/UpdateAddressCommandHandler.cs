using Multishop.Order.Application.Features.CQRS.Commands.AddressCommands;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var response = await _repository.GetByIdAsync(command.AddressId);
            if (response != null)
            {
                response.Detail = command.Detail;
                response.District = command.District;
                response.City = command.City;
                response.UserId = command.UserId;
                await _repository.UpdateAsync(response);
            }
        }
    }
}
