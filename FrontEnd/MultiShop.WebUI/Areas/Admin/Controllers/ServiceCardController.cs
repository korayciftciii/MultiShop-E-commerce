using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ServiceCardDtos;
using MultiShop.WebUI.Services.CatalogServices.ServiceCardServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceCardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IServiceCardService _serviceCardService;
        public ServiceCardController(IHttpClientFactory httpClientFactory, IServiceCardService serviceCardService)
        {
            _httpClientFactory = httpClientFactory;
            _serviceCardService = serviceCardService;
        }

        public async Task<IActionResult> Index()
        {
            var value =await _serviceCardService.ServiceCardList();
            return value is not null ? View(value) : View();
        }
        [HttpGet]

        public IActionResult NewServiceCard()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewServiceCard(CreateServiceCardDto createServiceCardDto)
        {
            await _serviceCardService.CreateServiceCard(createServiceCardDto); 
                return RedirectToAction("Index", "ServiceCard", new { area = "Admin" });
            
        }
        [HttpGet]
        public async Task<IActionResult> DeleteServiceCard([FromQuery(Name = "servicecardId")] string id)
        {
            await _serviceCardService.DeleteServiceCard(id);
                return RedirectToAction("Index", "ServiceCard", new { area = "Admin" });
            
        }

        [HttpGet]
        public async Task<IActionResult> UpdateServiceCard([FromQuery(Name = "servicecardId")] string id)
        {
            var value=await _serviceCardService.GetByIdServiceCardDto(id);
            return value is not null ? View(value) : View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateServiceCard([FromForm] UpdateServiceCardDto updateServiceCardDto)
        {
               await _serviceCardService.UpdateServiceCard(updateServiceCardDto);
                return RedirectToAction("Index", "ServiceCard", new { area = "Admin" });
            
        }
    }
}
