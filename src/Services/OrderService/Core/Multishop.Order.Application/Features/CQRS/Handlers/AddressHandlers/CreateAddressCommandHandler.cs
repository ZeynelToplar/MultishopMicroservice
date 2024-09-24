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
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAdressCommand createAdressCommand)
        {
            await _repository.CreateAsync(new Address()
            {
                City = createAdressCommand.City,
                Detail = createAdressCommand.Detail,
                District = createAdressCommand.District,
                UserId = createAdressCommand.UserId,
            });
        }
    }
}
