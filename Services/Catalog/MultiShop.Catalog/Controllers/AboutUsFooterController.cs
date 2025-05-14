using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.AboutUsFooter;
using MultiShop.Catalog.Services.AboutUsFooterServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsFooterController : ControllerBase
    {
        private readonly IAboutUsFooterService _aboutUsFooterService;

        public AboutUsFooterController(IAboutUsFooterService aboutUsFooterService)
        {
            _aboutUsFooterService = aboutUsFooterService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAboutUsFooterListAsync()
        {
            var result = await _aboutUsFooterService.GetAboutUsFooterAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutUsFooterByIdAsync(string id)
        {
            var result = await _aboutUsFooterService.GetAboutUsFooterByIdAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAboutUsFooterAsync([FromBody] CreateAboutUsFooterDto createAboutUsFooterDto)
        {
            await _aboutUsFooterService.CreateAboutUsFooterAsync(createAboutUsFooterDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAboutUsFooterAsync([FromBody] UpdateAboutUsFooterDto updateAboutUsFooterDto)
        {
            await _aboutUsFooterService.UpdateAboutUsFooterAsync(updateAboutUsFooterDto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAboutUsFooterAsync(string id)
        {
            await _aboutUsFooterService.DeleteAboutUsFooterAsync(id);
            return Ok();
        }
    }
}
