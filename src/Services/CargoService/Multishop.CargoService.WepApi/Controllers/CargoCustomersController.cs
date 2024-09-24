using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.CargoService.Business.Abstract;
using Multishop.CargoService.Dto.Dtos.CargoCustomerDtos;
using Multishop.CargoService.Entity.Concrete;

namespace Multishop.CargoService.WepApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList9()
        {
            var response = _cargoCustomerService.TGetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var response = _cargoCustomerService.TGetById(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Name = createCargoCustomerDto.Name,
                Surname = createCargoCustomerDto.Surname,
                Address = createCargoCustomerDto.Address,
                City = createCargoCustomerDto.City,
                District = createCargoCustomerDto.District,
                Email = createCargoCustomerDto.Email,
                Phone = createCargoCustomerDto.Phone
            };

            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Kargo musteri ekleme islemi basariyla gerceklesti.");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo musteri silme islemi basariyla gerceklesti.");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                Name = updateCargoCustomerDto.Name,
                Surname = updateCargoCustomerDto.Surname,
                Address = updateCargoCustomerDto.Address,
                City = updateCargoCustomerDto.City,
                District = updateCargoCustomerDto.District,
                Email = updateCargoCustomerDto.Email,
                Phone = updateCargoCustomerDto.Phone
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Kargo musteri guncelleme islemi basariyla gerceklesti.");
        }
    }
}
