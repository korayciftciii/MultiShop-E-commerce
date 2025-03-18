using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components.ProductDetailViewComponents
{
    public class _ProductDetailInformationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
