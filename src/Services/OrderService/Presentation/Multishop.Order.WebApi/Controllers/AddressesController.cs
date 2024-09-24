using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Order.Application.Features.CQRS.Commands.AddressCommands;
using Multishop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using Multishop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace Multishop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryHandler _getAdressesQueryHandler;
        private readonly GetAddressByIdQueryHandler _getAddressesByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;

        public AddressesController(GetAddressQueryHandler getAdressesQueryHandler, GetAddressByIdQueryHandler getAddressesByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, RemoveAddressCommandHandler removeAddressCommandHandler)
        {
            _getAdressesQueryHandler = getAdressesQueryHandler;
            _getAddressesByIdQueryHandler = getAddressesByIdQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var response = await _getAdressesQueryHandler.Handle();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> AddressListById(int id)
        {
            var response = await _getAddressesByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAdressCommand createAdressCommand)
        {
            await _createAddressCommandHandler.Handle(createAdressCommand);
            return Ok("Adres bilgisi basariyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand updateAddressCommand)
        {
            await _updateAddressCommandHandler.Handle(updateAddressCommand);
            return Ok("Adres bilgisi basariyla guncellendi"); 
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
            return Ok("Adres bilgisi basariyla kaldirildi");
        }
    }
}
