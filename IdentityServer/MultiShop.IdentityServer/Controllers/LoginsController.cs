﻿using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using MultiShop.IdentityServer.Tools;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace MultiShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;
        public LoginsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IHttpClientFactory httpClientFactory)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto userLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(userLogin.userName, userLogin.password, (userLogin.isPersistence ? userLogin.isPersistence : false), true);
            var user = await _userManager.FindByNameAsync(userLogin.userName);
            if (result.Succeeded)
            {
                GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                model.UserName = userLogin.userName;
                model.Id = user.Id;
                var token = JwtTokenGenerator.GenerateToken(model);
                return Ok(token);

            }
            else
            {
                return BadRequest("Access Denied | Password or user name is incorrect");
            }
        }
    }
}
