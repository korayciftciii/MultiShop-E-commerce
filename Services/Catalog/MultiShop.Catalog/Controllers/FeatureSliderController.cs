using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Controllers
{
   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSliderController : ControllerBase
    {
        private readonly IFeatureSliderService _FeatureSliderService;
        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _FeatureSliderService = featureSliderService;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureSliderList()
        {
            var values = await _FeatureSliderService.GetSlidersAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureSliderById(string id)
        {
            var value = await _FeatureSliderService.GetByIdFeatureSliderAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto FeatureSliderDto)
        {
            await _FeatureSliderService.CreateFeatureSliderAsync(FeatureSliderDto);
            return Ok($"The {FeatureSliderDto.Title} Slider   had been successfully created ");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _FeatureSliderService.DeleteFeatureSliderAsync(id);
            return Ok($"FeatureSlider number {id} had been successfully deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto FeatureSliderDto)
        {
            await _FeatureSliderService.UpdateFeatureSliderAsync(FeatureSliderDto);
            return Ok("FeatureSlider Had Been Successfully Updated");
        }

    }
}
