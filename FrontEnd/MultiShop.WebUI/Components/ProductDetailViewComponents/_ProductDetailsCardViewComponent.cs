using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components.ProductDetailViewComponents
{
    public class _ProductDetailsCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
             
    }
}
