using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components.DefaultViewComponents
{
    public class _SpecialOfferViewComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
