using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components.UIViewComponents
{
    public class _FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
