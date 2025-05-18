using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.GeneralOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.GeneralOfferServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GeneralOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IGeneralOfferService _generalOfferService;

        public GeneralOfferController(IHttpClientFactory httpClientFactory, IGeneralOfferService generalOfferService)
        {
            _httpClientFactory = httpClientFactory;
            _generalOfferService = generalOfferService;
        }

        public async Task<IActionResult> Index()
        {
        var value=await _generalOfferService.GeneralOfferListAsync();
            return value is not null ? View(value) : View();
        }
        [HttpGet]

        public IActionResult NewGeneralOffer()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewGeneralOffer(CreateGeneralOfferDto generalOfferDto)
        {
            await _generalOfferService.CreateGeneralOfferAsync(generalOfferDto);
                return RedirectToAction("Index", "GeneralOffer", new { area = "Admin" });
            
        }
        [HttpGet]
        public async Task<IActionResult> DeleteGeneralOffer([FromQuery(Name = "generalOfferId")] string id)
        {
            await _generalOfferService.DeleteGeneralOfferAsync(id);
                return RedirectToAction("Index", "GeneralOffer", new { area = "Admin" });
            
        }

        [HttpGet]
        public async Task<IActionResult> UpdateGeneralOffer([FromQuery(Name = "generalOfferId")] string id)
        {
           var value =await _generalOfferService.GetGeneralOfferByIdAsync(id);
            return value is not null ? View(value) : View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGeneralOffer([FromForm] UpdateGeneralOfferDto generalOfferDto)
        {
            await _generalOfferService.UpdateGeneralOfferAsync(generalOfferDto);
                return RedirectToAction("Index", "GeneralOffer", new { area = "Admin" });
            
        }
    }
}
