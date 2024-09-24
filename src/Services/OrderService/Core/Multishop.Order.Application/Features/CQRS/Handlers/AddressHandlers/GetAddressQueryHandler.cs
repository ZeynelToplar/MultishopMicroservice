using Multishop.Order.Application.Features.CQRS.Results.AddressResults;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var response = await _repository.GetAllAsync();
            return response.Select(r => new GetAddressQueryResult
            {
              AddressId = r.AddressId,
              City = r.City,
              Detail = r.Detail,
              District = r.District,
              UserId = r.UserId,
            }).ToList();
        }
    }
}
