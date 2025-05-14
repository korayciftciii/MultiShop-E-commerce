using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ServiceCardDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ServiceCardServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCardController : ControllerBase
    {
        private readonly IServiceCardService _serviceCardService;

        public ServiceCardController(IServiceCardService serviceCardService)
        {
            _serviceCardService = serviceCardService;
        }
        [HttpGet]
        public async Task<IActionResult> ServiceCardList()
        {
            var values = await _serviceCardService.ServiceCardList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceCardById(string id)
        {
            var value = await _serviceCardService.GetByIdServiceCardDto(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateServiceCard(CreateServiceCardDto ServiceCardDto)
        {
            await _serviceCardService.CreateServiceCard(ServiceCardDto);
            return Ok($"The {ServiceCardDto.Title} Service Card   had been successfully created ");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceCard(string id)
        {
            await _serviceCardService.DeleteServiceCard(id);
            return Ok($"ServiceCard number {id} had been successfully deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateServiceCard(UpdateServiceCardDto ServiceCardDto)
        {
            await _serviceCardService.UpdateServiceCard(ServiceCardDto);
            return Ok("ServiceCard Had Been Successfully Updated");
        }

    }
}
