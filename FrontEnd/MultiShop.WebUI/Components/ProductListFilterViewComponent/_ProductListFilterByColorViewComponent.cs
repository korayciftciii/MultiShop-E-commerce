using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components.ProductListFilterViewComponent
{
    public class _ProductListFilterByColorViewComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
