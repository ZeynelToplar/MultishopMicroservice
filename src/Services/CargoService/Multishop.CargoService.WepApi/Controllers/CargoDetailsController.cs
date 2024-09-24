using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.CargoService.Business.Abstract;
using Multishop.CargoService.Dto.Dtos.CargoDetailDtos;
using Multishop.CargoService.Entity.Concrete;

namespace Multishop.CargoService.WepApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]

        public IActionResult CargoDetailList()
        {
            var response = _cargoDetailService.TGetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var response = _cargoDetailService.TGetById(id);
            return Ok(response);

        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Barcode = createCargoDetailDto.Barcode,
                CargoCompanyId = createCargoDetailDto.CargoCompanyId,
                ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
                SenderCustomer = createCargoDetailDto.SenderCustomer,

            };
            _cargoDetailService.TInsert(cargoDetail);
            return Ok("Kargo detayi basariyla olusturuldu");
        }

        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo detayi basariyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {

            CargoDetail cargoDetail = new CargoDetail()
            {
                CargoDetailId = updateCargoDetailDto.CargoDetailId,
                Barcode = updateCargoDetailDto.Barcode,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
                ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
                SenderCustomer = updateCargoDetailDto.SenderCustomer,

            };
            _cargoDetailService.TUpdate(cargoDetail);
            return Ok("Kargo detayi basariyla guncellendi");
        }
    }
}
