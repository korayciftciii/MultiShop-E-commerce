using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutUsFooterDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutUsFooterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutUsFooterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/AboutUsFooter");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutUsFooterDto>>(JsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]

        public IActionResult NewAboutUsFooter()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewAboutUsFooter(CreateAboutUsFooterDto createAboutUsFooterDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAboutUsFooterDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7070/api/AboutUsFooter", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AboutUsFooter", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteAboutUsFooter([FromQuery(Name = "aboutUsId")] string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7070/api/AboutUsFooter?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AboutUsFooter", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAboutUsFooter([FromQuery(Name = "aboutUsId")] string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/AboutUsFooter/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAboutUsFooterDto>(JsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAboutUsFooter([FromForm] UpdateAboutUsFooterDto updateAboutUsFooterDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAboutUsFooterDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7070/api/AboutUsFooter", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AboutUsFooter", new { area = "Admin" });
            }
            return View();
        }
    }
}
