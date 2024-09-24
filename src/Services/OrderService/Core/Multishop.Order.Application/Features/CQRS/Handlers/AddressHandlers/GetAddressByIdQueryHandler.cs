using Multishop.Order.Application.Features.CQRS.Queries.AddressQueries;
using Multishop.Order.Application.Features.CQRS.Results.AddressResults;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery request)
        {
            var response = await _repository.GetByIdAsync(request.Id);
            return new GetAddressByIdQueryResult
            {
                AddressId = response.AddressId,
                City = response.City,
                Detail = response.Detail,
                District = response.District,
                UserId = response.UserId
            };
        }
    }
}
