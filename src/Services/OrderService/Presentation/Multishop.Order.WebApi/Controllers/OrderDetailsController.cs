using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Multishop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Multishop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace Multishop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;

        public OrderDetailsController(GetOrderDetailQueryHandler getOrderDetailQueryHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler)
        {
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var response = await _getOrderDetailQueryHandler.Handle();
            return Ok(response);    
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> OrderDetailById(int id)
        {
            var response = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await _createOrderDetailCommandHandler.Handle(createOrderDetailCommand);
            return Ok("Siparis detayi basariyla olusturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            await _updateOrderDetailCommandHandler.Handle(updateOrderDetailCommand);
            return Ok("Siparis detayi basariyla guncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetail(RemoveOrderDetailCommand removeOrderDetailCommand)
        {
            await _removeOrderDetailCommandHandler.Handle(removeOrderDetailCommand);
            return Ok("Siparis detayi basariyla silindi");
        }
    }
}
