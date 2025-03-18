using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components.ShoppingCartViewComponents
{
    public class _ShoppingCartActionSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
