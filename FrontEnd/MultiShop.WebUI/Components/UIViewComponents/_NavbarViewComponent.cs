using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components.UIViewComponents
{
    public class _NavbarViewComponent:ViewComponent
    {
        public  IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
