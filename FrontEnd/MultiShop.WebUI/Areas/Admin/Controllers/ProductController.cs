using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
       private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IProductDetailService _productDetailService;
        private readonly IProductImageService _productImageService;
        public ProductController(IHttpClientFactory httpClientFactory, IProductService productService, ICategoryService categoryService, IProductDetailService productDetailService, IProductImageService productImageService)
        {
            _httpClientFactory = httpClientFactory;
            _productService = productService;
            _categoryService = categoryService;
            _productDetailService = productDetailService;
            _productImageService = productImageService;
        }
        public async Task<List<SelectListItem>> GetCategoriesViewBag()
        {
            var values=await _categoryService.GetAllCategoriesAsync();
            return values != null ? values.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList() :  new List<SelectListItem>(); 
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct([FromQuery(Name = "productId")] string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
            
           
        }
        public async Task<IActionResult> Index()
        {
          var values=await _productService.GetAllProductsAsync();
                return View(values);
        }

        public async Task<IActionResult> ProductImages(string productId)
        {
            var value=await _productImageService.GetByIdProductImagesAsync(productId);
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> NewProduct()
        {
            ViewBag.Categories = await GetCategoriesViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewProduct([FromForm] CreateProductDto createProductDto)
        {

          await _productService.CreateProductAsync(createProductDto);
          
          return RedirectToAction("Index", "Product", new { area = "Admin" });
          
          
        }
 
        [HttpGet]
        public async Task<IActionResult> UpdateProduct([FromQuery(Name = "productId")] string id)
        {
            var value=await _productService.GetOneProductForUpdate(id);
            
            if (value !=null)
            {    
                ViewBag.Categories = await GetCategoriesViewBag();
                return View(value);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductDto updateProductDto)
        {
                await _productService.UpdateProductAsync(updateProductDto);
                return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateImages(string productId)
        {
           var value =await _productImageService.GetProductImagesForUpdate(productId);
            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateImages([FromForm] UpdateProductImageDto updateProductImageDto)
        {
                 await _productImageService.UpdateProductImagesAsync(updateProductImageDto);

            return RedirectToAction("Index", "Product", new { area = "Admin" });
     
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProductDetail(string productId)
        {
            var value = _productDetailService.GetProductDetailsForUpdate(productId);
                return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProductDetail([FromForm] UpdateProductDetailsDto updateProductDetailsDto)
        {
          await _productDetailService.UpdateProductDetailsAsync(updateProductDetailsDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
          
        }
    }
}
