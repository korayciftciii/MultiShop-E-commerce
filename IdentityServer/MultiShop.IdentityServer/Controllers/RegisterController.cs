using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;

namespace MultiShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            var values = new ApplicationUser
            {
                Name=userRegisterDto.Name,
                Email=userRegisterDto.Email,
                Surname=userRegisterDto.Surname,
            };
            var result=await _userManager.CreateAsync(values,userRegisterDto.Password);
            if (result.Succeeded)
                return Ok("The Registration had been completed successfully");
            else
                return Ok("An error occured while registrating new user"); 
        }
    }
}
