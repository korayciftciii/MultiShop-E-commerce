using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components.DefaultViewComponents
{
    public class _FeaturedProductsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
