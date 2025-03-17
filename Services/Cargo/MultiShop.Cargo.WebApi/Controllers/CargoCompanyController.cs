using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinnessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _service;

        public CargoCompanyController(ICargoCompanyService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _service.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult CargoById(int id)
        {
            var value=_service.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyName=createCargoCompanyDto.CargoCompanyName
            };

            _service.TInsert(cargoCompany);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany() { 
            CargoCompanyId=updateCargoCompanyDto.CargoCompanyId,
            CargoCompanyName=updateCargoCompanyDto.CargoCompanyName
            };
            _service.TUpdate(cargoCompany);
            return Ok();
        }
        [HttpDelete]
        public IActionResult RemoveCargoCompany(int id)
        {
            _service.TDelete(id);
            return Ok();
        }
    }
}
