using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.CargoService.Business.Abstract;
using Multishop.CargoService.Dto.Dtos.CargoCompanyDtos;
using Multishop.CargoService.Entity.Concrete;

namespace Multishop.CargoService.WepApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var response = _cargoCompanyService.TGetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var response = _cargoCompanyService.TGetById(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyName = createCargoCompanyDto.CargoCompanyName,
            };
            _cargoCompanyService.TInsert(cargoCompany);
            return Ok("Kargo sirketi basariyla olusturuldu");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Kargo sirketi basariyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyName = updateCargoCompanyDto.CargoCompanyName,
                CargoCompanyId = updateCargoCompanyDto.CargoCompanyId
            };
            _cargoCompanyService.TUpdate(cargoCompany);
            return Ok("Kargo sirketi basariyla guncellendi");
        }
    }
}
