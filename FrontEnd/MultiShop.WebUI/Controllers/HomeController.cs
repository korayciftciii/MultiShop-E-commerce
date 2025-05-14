using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services;

namespace MultiShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoginService _loginService;

        public HomeController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Index()
        {
           

            return View();
        }
    }
}
