using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await  _productService.GetAllProductsAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var value = await _productService.GetByIdProductAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto productDto)
        {
            await _productService.CreateProductAsync(productDto);
            return Ok($"The {productDto.ProductName} Product   had been successfully created ");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok($"Product number {id} had been successfully deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto productDto)
        {
            await _productService.UpdateProductAsync(productDto);
            return Ok("Product Had Been Successfully Updated");
        }
        [HttpGet("productlistwithcategory")]
        public async Task<IActionResult> productlistwithcategory()
        {
         var item=   await _productService.GetProductsWithCategoryAsync();
            return Ok(item);
        }
        [HttpGet("productlistwithcategoryId")]
        public async Task<IActionResult> productlistwithcategoryId(string id)
        {
            var item = await _productService.GetProductsWithCategoryIdAsync(id);
            return Ok(item);
        }
    }
}
    