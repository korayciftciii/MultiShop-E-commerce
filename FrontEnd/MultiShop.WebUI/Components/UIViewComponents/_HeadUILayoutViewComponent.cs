using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components.UIViewComponents
{
    public class _HeadUILayoutViewComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
