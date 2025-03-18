using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components.ProductListFilterViewComponent
{
    public class _ProductListFilterBySizeViewComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
