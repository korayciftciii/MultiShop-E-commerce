using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components.DefaultViewComponents
{
    public class _FeaturedProductSliderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
