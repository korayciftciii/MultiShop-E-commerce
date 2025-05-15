using Duende.IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Settings;
using System.Security.Claims;

namespace MultiShop.WebUI.Services.Concrete
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ClientSettings _clientSettings;

        public IdentityService(HttpClient httpClient, IHttpContextAccessor contextAccessor, IOptions<ClientSettings> clientSettings)
        {
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
            _clientSettings = clientSettings.Value;
        }

        public async Task<bool> Signin(SigninDto signinDto)
        {
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address= "https://localhost:5001",
                //Policy=new DiscoveryPolicy{

                //}
            });
            var passwordTokenRequest = new PasswordTokenRequest
            {
                ClientId = _clientSettings.MultiShopManagerClient.ClientId,
                ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
                UserName = signinDto.UserName,
                Password = signinDto.Password,
                Address = discoveryEndPoint.TokenEndpoint,
            };
            var Token=await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);
            var userInformationRequest= new UserInfoRequest
            { 
                 Token=Token.AccessToken,
                 Address=discoveryEndPoint.UserInfoEndpoint,

            };
            var userVlues=await _httpClient.GetUserInfoAsync(userInformationRequest);
            ClaimsIdentity claimsIdentity=new ClaimsIdentity(userVlues.Claims,CookieAuthenticationDefaults.AuthenticationScheme,"name","role");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            var authenticationProperties = new AuthenticationProperties();
            authenticationProperties.StoreTokens(new List<AuthenticationToken>() { 
            
              new AuthenticationToken
              {
                  Name=OpenIdConnectParameterNames.AccessToken,
                  Value=Token.AccessToken,
              },
              new AuthenticationToken{ 
              Name=OpenIdConnectParameterNames.RefreshToken,
              Value=Token.RefreshToken
              },
              new AuthenticationToken
              {
                  Name=OpenIdConnectParameterNames.ExpiresIn,
                  Value=DateTime.Now.AddSeconds(Token.ExpiresIn).ToString()
              }
            });

            authenticationProperties.IsPersistent= (signinDto.IsPersistence ? true : false);
            await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);
            return true;

        }
    }
}
