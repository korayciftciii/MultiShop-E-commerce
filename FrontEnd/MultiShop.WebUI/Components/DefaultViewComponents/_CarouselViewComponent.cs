using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components.DefaultViewComponents
{
    public class _CarouselViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
