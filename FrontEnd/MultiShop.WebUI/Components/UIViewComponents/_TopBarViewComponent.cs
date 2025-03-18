using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components.UIViewComponents
{
    public class _TopBarViewComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
