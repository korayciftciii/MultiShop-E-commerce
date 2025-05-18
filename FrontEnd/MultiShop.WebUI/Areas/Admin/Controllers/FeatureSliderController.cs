using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureSliderController : Controller
    {
        private readonly IFeatureSliderService _featureSliderService;


        public FeatureSliderController( IFeatureSliderService featureSliderService)
        {
     
            _featureSliderService = featureSliderService;
        }

        public async Task<IActionResult> Index()
        {
            var value=await _featureSliderService.GetAllFeatureSliderAsync();
            return value is not null ? View(value) : View();
        }
        [HttpGet]

        public IActionResult NewFeatureSlider()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewFeatureSlider(CreateFeatureSliderDto createSliderDto)
        {
            await _featureSliderService.CreateFeatureSliderAsync(createSliderDto);
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            
        }
        [HttpGet]
        public async Task<IActionResult> DeleteSlider([FromQuery(Name = "sliderId")] string id)
        {
                  await _featureSliderService.DeleteFeatureSliderAsync(id);

                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider([FromQuery(Name = "sliderId")] string id)
        {
            var value=await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return value is not null ? View(value) : View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider([FromForm] UpdateFeatureSliderDto  updateSliderDto)
        {
        await _featureSliderService.UpdateFeatureSliderAsync(updateSliderDto);
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        
        }
    }
}
