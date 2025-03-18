using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components.UIViewComponents
{
    public class _ScriptUILayoutViewComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
