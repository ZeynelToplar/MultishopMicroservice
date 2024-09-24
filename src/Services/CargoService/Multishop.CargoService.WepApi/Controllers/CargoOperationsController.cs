using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.CargoService.Business.Abstract;
using Multishop.CargoService.Dto.Dtos.CargoOperationDtos;
using Multishop.CargoService.Entity.Concrete;

namespace Multishop.CargoService.WepApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]

        public IActionResult CargoOperationList()
        {
            var response = _cargoOperationService.TGetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var response = _cargoOperationService.TGetById(id);
            return Ok(response);

        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate,
            };
            _cargoOperationService.TInsert(cargoOperation);
            return Ok("Kargo operasyonu basariyla olusturuldu");
        }

        [HttpDelete]
        public IActionResult DeleteCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo operasyonu basariyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {

            CargoOperation cargoOperation = new CargoOperation()
            {
                CargoOperationId = updateCargoOperationDto.CargoOperationId,
                Barcode = updateCargoOperationDto.Barcode,
                Description = updateCargoOperationDto.Description,
                OperationDate = updateCargoOperationDto.OperationDate,
            };
            _cargoOperationService.TUpdate(cargoOperation);
            return Ok("Kargo operasyonu basariyla guncellendi");
        }
    }
}
