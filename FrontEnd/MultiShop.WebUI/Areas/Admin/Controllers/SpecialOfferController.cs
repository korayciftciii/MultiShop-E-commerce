using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {   
            _specialOfferService = specialOfferService;
        }

        public async Task<IActionResult> Index()
        {
           var values=await _specialOfferService.SpecialOfferListAsync();
            return values is not null ? View(values) : View();
        }
        [HttpGet]

        public IActionResult NewSpecialOffer()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewSpecialOffer(CreateSpecialOfferDto specialOfferDto)
        {
           await _specialOfferService.CreateSpecialOfferAsync(specialOfferDto);

                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
           
           
        }
        [HttpGet]
        public async Task<IActionResult> DeleteSpecialOffer([FromQuery(Name = "offerId")] string id)
        {
          await _specialOfferService.DeleteSpecialOfferAsync(id);
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
           
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer([FromQuery(Name = "offerId")] string id)
        {
           var value =await _specialOfferService.GetSpecialOfferByIdAsync(id);
            return value is not null ? View(value) : View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer([FromForm] UpdateSpecialOfferDto specialOfferDto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(specialOfferDto);
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            
        }
    }
}
