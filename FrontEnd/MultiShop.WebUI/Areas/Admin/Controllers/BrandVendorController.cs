using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandVendorDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandVendorServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandVendorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IBrandVendorService _brandVendor;


        public BrandVendorController(IHttpClientFactory httpClientFactory, IBrandVendorService brandVendor)
        {
            _httpClientFactory = httpClientFactory;
            _brandVendor = brandVendor;
        }


        public async Task<IActionResult> Index()
        {
           var value=await _brandVendor.BrandVendorListAsync();
            return value is not null ? View(value) : View();
        }
        [HttpGet]

        public IActionResult NewBrandVendor()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewBrandVendor(CreateBrandVendorDto createBrandVendorDto)
        {
            await _brandVendor.CreateBrandVendorAsync(createBrandVendorDto);
               return RedirectToAction("Index", "BrandVendor", new { area = "Admin" });
            
 
        }
        [HttpGet]
        public async Task<IActionResult> DeleteBrandVendor([FromQuery(Name = "vendorId")] string id)
        {
                      await _brandVendor.DeleteBrandVendorAsync(id);
                return RedirectToAction("Index", "BrandVendor", new { area = "Admin" });
            
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrandVendor([FromQuery(Name = "vendorId")] string id)
        {
            var value=await _brandVendor.GetByIdVendorAsync(id);
            return value is not null ?  View(value) : View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrandVendor([FromForm] UpdateBrandVendorDto updateBrandVendorDto)
        {
                    await _brandVendor.UpdateBrandVendorAsync(updateBrandVendorDto);
                return RedirectToAction("Index", "BrandVendor", new { area = "Admin" });
            
        }
    }
}
