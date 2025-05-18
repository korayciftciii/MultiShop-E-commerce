using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
namespace MultiShop.WebUI.Components.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderViewComponent :ViewComponent
    {
    
        private readonly IProductImageService _productImageService;
        public _ProductDetailImageSliderViewComponent(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var value=await _productImageService.GetByIdProductImagesAsync(id);
            
                return value!=null ? View(value) : View();
            
            
        }
    }
}
