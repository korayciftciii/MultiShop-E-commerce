using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var userData = User.Claims;

            return View();
        }
    }
}
