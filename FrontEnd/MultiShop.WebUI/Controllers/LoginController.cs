using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using System.Text;
using System.Text.Json;
using MultiShop.WebUI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using MultiShop.WebUI.Services;
namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:5001/api/Logins", content);
            if(response.IsSuccessStatusCode)
            {
                var jsonData=await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData,new JsonSerializerOptions { 
                PropertyNamingPolicy=JsonNamingPolicy.CamelCase

                });
                if(tokenModel !=null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();
                     var expiresUtc = DateTime.UtcNow.AddSeconds(tokenModel.ExpireDate);
                    if (tokenModel.Token !=null)
                    {
                        claims.Add(new Claim("multishoptoken",tokenModel.Token));
                        var claimsIdentity= new ClaimsIdentity(claims,JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties 
                        {
                         ExpiresUtc=expiresUtc,
                         IsPersistent=true,
                        };
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        var userId = _loginService.GetUserId;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();

        }
    }
}
