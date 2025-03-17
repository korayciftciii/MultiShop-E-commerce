using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinnessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _service;

        public CargoDetailController(ICargoDetailService service)
        {
            _service = service;
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _service.TDelete(id);
            return Ok();
        }
        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _service.TGetAll();
            return  Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult CargoDetailById(int id)
        {
            var value=_service.TGetById(id);    
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail cargoDetail= new CargoDetail()
            {
                Barcode= createCargoDetailDto.Barcode,
                CargoCompanyId=createCargoDetailDto.CargoCompanyId,
                ReceiverCustomer=createCargoDetailDto.ReceiverCustomer,
                SenderCustomer=createCargoDetailDto.SenderCustomer,
            };
            _service.TInsert(cargoDetail);
            return Ok();

        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Barcode = updateCargoDetailDto.Barcode,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
                ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
                SenderCustomer = updateCargoDetailDto.SenderCustomer,
            };
            _service.TUpdate(cargoDetail);
            return Ok();
        }
    }
}
