using MediatR;
using Multishop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using Multishop.Order.Application.Features.Mediator.Results.OrderingResults;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetAllAsync();
            return response.Select(r => new GetOrderingQueryResult
            {
                OrderingId = r.OrderingId,
                OrderDate = r.OrderDate,
                TotalPrice = r.TotalPrice,
                UserId = r.UserId
            }).ToList();
        }
    }
}
