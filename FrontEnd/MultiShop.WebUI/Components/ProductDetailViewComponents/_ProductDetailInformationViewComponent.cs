using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
namespace MultiShop.WebUI.Components.ProductDetailViewComponents
{
    public class _ProductDetailInformationViewComponent : ViewComponent
    {

       
        private readonly IProductDetailService _productDetailService;
        public _ProductDetailInformationViewComponent( IProductDetailService productDetailService)
        {
         
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values=await _productDetailService.GetByIdProductDetailAsync(id);
            
           return values!=null ? View(values) : View();
          
        }
    }
}
