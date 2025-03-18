using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components.ContactViewComponents
{
    public class _ContactInformationViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
