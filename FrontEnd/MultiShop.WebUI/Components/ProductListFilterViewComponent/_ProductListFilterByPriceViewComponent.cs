using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components.ProductListFilterViewComponent
{
    public class _ProductListFilterByPriceViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
