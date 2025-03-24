using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandVendorDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandVendorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BrandVendorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/BrandVendor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandVendorDto>>(JsonData);
                return View(values);
            }
            return View();
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
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBrandVendorDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7070/api/BrandVendor", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "BrandVendor", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteBrandVendor([FromQuery(Name = "vendorId")] string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7070/api/BrandVendor?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "BrandVendor", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrandVendor([FromQuery(Name = "vendorId")] string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/BrandVendor/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBrandVendorDto>(JsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrandVendor([FromForm] UpdateBrandVendorDto updateBrandVendorDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBrandVendorDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7070/api/BrandVendor", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "BrandVendor", new { area = "Admin" });
            }
            return View();
        }
    }
}
