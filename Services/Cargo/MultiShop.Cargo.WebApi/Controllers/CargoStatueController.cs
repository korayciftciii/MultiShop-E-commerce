using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinnessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoStatueDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoStatueController : ControllerBase
    {
        private readonly ICargoStatueService _service;

        public CargoStatueController(ICargoStatueService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult CargoStatueList()
        {
            var values=_service.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult CargoStatueById(int id)
        {
            var value=_service.TGetById(id);
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult RemoveCargoStatue(int id)
        {
            _service.TDelete(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateCargoStatue(CreateCargoStatueDto createCargoStatueDto)
        {
            CargoStatue cargoStatue = new CargoStatue()
            {
                Barcode=createCargoStatueDto.Barcode,
                Description=createCargoStatueDto.Description,
                OperationDate=createCargoStatueDto.OperationDate
            };
            _service.TInsert(cargoStatue);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCargoStatue(UpdateCargoStatueDto updateCargoStatueDto)
        {
            CargoStatue cargoStatue = new CargoStatue()
            {
                Barcode = updateCargoStatueDto.Barcode,
                Description = updateCargoStatueDto.Description,
                OperationDate = updateCargoStatueDto.OperationDate
            };
            _service.TUpdate(cargoStatue);
            return Ok();
        }
    }
}
