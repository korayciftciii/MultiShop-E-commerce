using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinnessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _service;

        public CargoCustomerController(ICargoCustomerService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _service.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult CargoCustomerById(int id)
        {
            var value=_service.TGetById(id);
            return Ok(value);   
        }
        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _service.TDelete(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer=new CargoCustomer() { 
            Address = updateCargoCustomerDto.Address,
            CargoCustomerId=updateCargoCustomerDto.CargoCustomerId,
            City = updateCargoCustomerDto.City,
            District = updateCargoCustomerDto.District,
            Email = updateCargoCustomerDto.Email,
            Name = updateCargoCustomerDto.Name,
            Phone = updateCargoCustomerDto.Phone,
            Surname=updateCargoCustomerDto.Surname,
            };
            _service.TUpdate(cargoCustomer);
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Address = createCargoCustomerDto.Address,
                City = createCargoCustomerDto.City,
                District = createCargoCustomerDto.District,
                Email = createCargoCustomerDto.Email,
                Name = createCargoCustomerDto.Name,
                Phone = createCargoCustomerDto.Phone,
                Surname = createCargoCustomerDto.Surname,
            };
            _service.TInsert(cargoCustomer);
            return Ok();
        }
    }
}
