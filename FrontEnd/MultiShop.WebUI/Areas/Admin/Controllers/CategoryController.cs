using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using System.Text;
namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

    
        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Category");
            if(responseMessage.IsSuccessStatusCode)
            {
                var JsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(JsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
      
        public IActionResult NewCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(createCategoryDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var response = await client.PostAsync("https://localhost:7070/api/Category", stringContent);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Category",new { area="Admin"});
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCategory([FromQuery(Name="categoryId")]string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response=await client.DeleteAsync("https://localhost:7070/api/Category/"+id);
            if(response.IsSuccessStatusCode) 
                {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
                }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory([FromQuery(Name = "categoryId")] string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Category/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(JsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory([FromForm]UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7070/api/Category", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }
    }
}
