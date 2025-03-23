using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.GeneralOfferDtos;
using MultiShop.Catalog.Services.GeneralOfferServices;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralOfferController : ControllerBase
    {
        private readonly IGeneralOfferService _generalOfferService;

        public GeneralOfferController(IGeneralOfferService generalOfferService)
        {
            _generalOfferService = generalOfferService;
        }
        [HttpGet]
        public async Task<IActionResult> GeneralOfferList()
        {
            var values = await _generalOfferService.GeneralOfferListAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGeneralOfferById(string id)
        {
            var value = await _generalOfferService.GetGeneralOfferByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateGeneralOffer(CreateGeneralOfferDto generalOfferDto)
        {
            await _generalOfferService.CreateGeneralOfferAsync(generalOfferDto);
            return Ok($"The {generalOfferDto.Title} General Offer   had been successfully created ");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneralOffer(string id)
        {
            await _generalOfferService.DeleteGeneralOfferAsync(id);
            return Ok($"Offer number {id} had been successfully deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateGeneralOffer(UpdateGeneralOfferDto updateGeneralDto)
        {
            await _generalOfferService.UpdateGeneralOfferAsync(updateGeneralDto);
            return Ok("General Offer Had Been Successfully Updated");
        }
    }
}
