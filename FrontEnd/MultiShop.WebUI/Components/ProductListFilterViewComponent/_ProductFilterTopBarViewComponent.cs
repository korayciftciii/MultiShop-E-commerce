using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components.ProductListFilterViewComponent
{
    public class _ProductFilterTopBarViewComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
