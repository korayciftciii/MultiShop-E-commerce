using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.GeneralOfferDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GeneralOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GeneralOfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/GeneralOffer");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGeneralOfferDto>>(JsonData);
                return View(values);
            }
            return View();
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
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(generalOfferDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7070/api/GeneralOffer", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "GeneralOffer", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteGeneralOffer([FromQuery(Name = "generalOfferId")] string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7070/api/GeneralOffer/" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "GeneralOffer", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateGeneralOffer([FromQuery(Name = "generalOfferId")] string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/GeneralOffer/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateGeneralOfferDto>(JsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGeneralOffer([FromForm] UpdateGeneralOfferDto generalOfferDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(generalOfferDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7070/api/GeneralOffer", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "GeneralOffer", new { area = "Admin" });
            }
            return View();
        }
    }
}
