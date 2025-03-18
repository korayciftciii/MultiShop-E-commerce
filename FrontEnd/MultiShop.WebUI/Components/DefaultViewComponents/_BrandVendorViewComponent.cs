using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components.DefaultViewComponents
{
    public class _BrandVendorViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
