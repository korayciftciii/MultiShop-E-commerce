using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components.ProductListFilterViewComponent
{
    public class _ProductCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
