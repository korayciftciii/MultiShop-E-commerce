using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.Components.ProductDetailViewComponents
{
    public class _ProductDetailsCardViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductService _productService;
        public _ProductDetailsCardViewComponent(IHttpClientFactory httpClientFactory, IProductService productService)
        {
            _httpClientFactory = httpClientFactory;
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values=await _productService.GetByIdProductAsync(id);
            
                return values!=null ? View(values) : View();
            
        }
             
    }
}
