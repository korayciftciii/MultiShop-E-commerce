using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components.DefaultViewComponents
{
    public class _CategoriesSection : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
