using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.BrandVendor;
using MultiShop.Catalog.Services.BrandVendorServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandVendorController : ControllerBase
    {
       private readonly IBrandVendorService _brandVendorService;

        public BrandVendorController(IBrandVendorService brandVendorService)
        {
            _brandVendorService = brandVendorService;
        }
        [HttpGet]
        public async Task<IActionResult> BrandVendorList()
        {
            var values = await _brandVendorService.BrandVendorListAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandVendorById(string id)
        {
            var value = await _brandVendorService.GetByIdVendorAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrandVendor(CreateBrandVendorDto brandVendorDto)
        {
            await _brandVendorService.CreateBrandVendorAsync(brandVendorDto);
            return Ok($"The {brandVendorDto.BrandName} BrandVendor had been successfully created ");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBrandVendor(string id)
        {
            await _brandVendorService.DeleteBrandVendorAsync(id);
            return Ok($"BrandVendor number {id} had been successfully deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrandVendor(UpdateBrandVendorDto brandVendorDto)
        {
            await _brandVendorService.UpdateBrandVendorAsync(brandVendorDto);
            return Ok("BrandVendor Had Been Successfully Updated");
        }
    }
}
