using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICategoryService _categoryService;
        public CategoryController(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _categoryService = categoryService;
        }


        public async Task<IActionResult> Index()
        {
           var values=await _categoryService.GetAllCategoriesAsync();
            return View(values);
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
           await _categoryService.CreateCategoryAsync(createCategoryDto);
                return RedirectToAction("Index","Category",new { area="Admin"});
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCategory([FromQuery(Name="categoryId")]string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
                return RedirectToAction("Index", "Category", new { area = "Admin" });
          
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory([FromQuery(Name = "categoryId")] string id)
        {
          var value= await _categoryService.GetOneCategoryForUpdate(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory([FromForm]UpdateCategoryDto updateCategoryDto)
        {
           await _categoryService.UpdateCategoryAsync(updateCategoryDto);
                return RedirectToAction("Index", "Category", new { area = "Admin" });
           
        }
    }
}
