using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services;
using System.Security.Claims;

namespace MultiShop.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILoginService loginService;

        public HomeController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
